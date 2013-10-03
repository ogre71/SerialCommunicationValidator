using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace SerialCommunicationVerifier
{
  public partial class TcpIpCommunicationUserControl : CommunicationUserControl
  {
    private System.Net.Sockets.TcpClient tcpClient;
    private byte[] buffer; 
    
    public TcpIpCommunicationUserControl() : base(null, null, null)
    {
      this.InitializeComponent();
    }

    public TcpIpCommunicationUserControl(Action<Font, string> writeToDisplay, Action onConnected, Action onDisconnected) : base(writeToDisplay, onConnected, onDisconnected)
    {
      this.InitializeComponent(); 

      textBoxInstrumentAddress.Text = Properties.Settings.Default.DnsName;

      Properties.Settings.Default.ActiveRadioButton = "TCP/IP";
      Properties.Settings.Default.Save();
    }
    
    private void buttonDone_Click(object sender, EventArgs e)
    {
      if (this.buttonDone.Text == "&Connect")
      {
        try
        {
          tcpClient = new TcpClient(this.textBoxInstrumentAddress.Text, 7777);
        }
        catch (SocketException sex)
        {
          MessageBox.Show("Error trying to communicate with " + this.textBoxInstrumentAddress.Text);
          this.onDisconnected(); 
          return; 
        }

        this.textBoxInstrumentAddress.Enabled = false; 

        buffer = new byte[1024];
        AsyncCallback callback = new AsyncCallback(Receive);

        tcpClient.GetStream().BeginRead(buffer, 0, 1024, callback, tcpClient);

        this.onConnected();
        this.buttonDone.Text = "&Close";
      }
      else
      {
        this.textBoxInstrumentAddress.Enabled = true; 
        this.buttonDone.Text = "&Connect";
        this.Close(); 
      }
    }

    private void Receive(IAsyncResult result)
    {
      if (!tcpClient.Connected)
      {
        return; 
      }

      string message = System.Text.ASCIIEncoding.ASCII.GetString(buffer);

      Font font = new Font("System", 10);
      writeToListBox(font, message);

      buffer = new byte[1024];
      AsyncCallback callback = new AsyncCallback(Receive);

      tcpClient.GetStream().BeginRead(buffer, 0, 1024, callback, tcpClient);
    }

    private void textBoxInstrumentAddress_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyData == Keys.Enter)
      {
        buttonDone_Click(null, null);
        if (this.buttonDone.Text == "&Connect")
        {
          return; 
        }
        
        this.Write("*idn?");
        Properties.Settings.Default.DnsName = textBoxInstrumentAddress.Text;
        Properties.Settings.Default.Save();
      }
    }

    public override void Write(string input)
    {
      input = input + "\r\n"; 
      byte[] buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(input);
      tcpClient.GetStream().Write(buffer, 0, buffer.Length);
    }

    public override void Close()
    {
      if (this.tcpClient != null)
      {
        this.tcpClient.Close();
      }

      this.onDisconnected();
    }

    private void textBoxInstrumentAddress_TextChanged(object sender, EventArgs e)
    {
      if (this.textBoxInstrumentAddress.Text.Contains(":"))
      {
        this.labelPort.Visible = false;
      }
      else
      {
        this.labelPort.Visible = true; 
      }
    }
  }
}
