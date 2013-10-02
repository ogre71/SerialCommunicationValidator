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
  public partial class TcpIpCommunicationUserControl : UserControl
  {
    public TcpIpCommunicationUserControl()
    {
      InitializeComponent();

      textBox1.Text = Properties.Settings.Default.DnsName;
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private Action<Font, string> writeToListBox;

    public void Initialize(Action<Font, string> writeToListBox)
    {
      this.writeToListBox = writeToListBox;

      if (this.DesignMode == true)
        return;

      Properties.Settings.Default.ActiveRadioButton = "TCP/IP";
      Properties.Settings.Default.Save();

    }

    System.Net.Sockets.TcpClient tcpClient;
    
    private void buttonDone_Click(object sender, EventArgs e)
    {
      tcpClient = new TcpClient(this.textBox1.Text, 7777);
      buffer = new byte[1024];
      AsyncCallback callback = new AsyncCallback(Receive);

      tcpClient.GetStream().BeginRead(buffer, 0, 1024, callback, tcpClient); 
    }

    byte[] buffer; 

    private void Receive(IAsyncResult result)
    {
      string message = System.Text.ASCIIEncoding.ASCII.GetString(buffer);

      Font font = new Font("System", 10);
      writeToListBox(font, message);

      buffer = new byte[1024];
      AsyncCallback callback = new AsyncCallback(Receive);

      tcpClient.GetStream().BeginRead(buffer, 0, 1024, callback, tcpClient); 
    }

    public void Write(string input)
    {
      input = input + "\r\n"; 
      byte[] buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(input);
      tcpClient.GetStream().Write(buffer, 0, buffer.Length);
    }

    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyData == Keys.Enter)
      {
        buttonDone_Click(null, null);
        this.Write("*idn?");
        Properties.Settings.Default.DnsName = textBox1.Text;
        Properties.Settings.Default.Save();
      }
    }
  }
}
