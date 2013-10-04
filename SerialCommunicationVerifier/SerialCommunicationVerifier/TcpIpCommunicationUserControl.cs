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
    internal interface ITcpClient
    {
      int ReceiveTimeout { get; set; }
      void Connect(string address, int port);
      System.IO.Stream GetStream();
      bool Connected { get;  }
      void Close(); 
    }

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    private class RealTcpClient : ITcpClient
    {
      private TcpClient tcpClient;
      public RealTcpClient(TcpClient client)
      {
        this.tcpClient = client; 
      }


      public int ReceiveTimeout
      {
        get
        {
          return this.tcpClient.ReceiveTimeout;
        }
        set
        {
          this.tcpClient.ReceiveTimeout = value; 
        }
      }

      public void Connect(string address, int port)
      {
        this.tcpClient.Connect(address, port); 
      }

      public void Close()
      {
        this.tcpClient.Close(); 
      }

      public System.IO.Stream GetStream()
      {
        return this.tcpClient.GetStream(); 
      }


      public bool Connected
      {
        get { return this.tcpClient.Connected; }
      }
    }

    private ITcpClient tcpClient;
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
    
    internal TcpIpCommunicationUserControl(Action<Font, string> writeToDisplay, Action onConnected, Action onDisconnected, ITcpClient client) : this(writeToDisplay, onConnected, onDisconnected)
    {
      this.tcpClient = client; 
    }

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    private ITcpClient GetTcpClient()
    {
      // If we're mocking, keep mocking.
      if (this.tcpClient != null && !(this.tcpClient is RealTcpClient))
      {
        return tcpClient;
      }

      tcpClient = new RealTcpClient(new TcpClient());
      tcpClient.ReceiveTimeout = 5000;
      return tcpClient;
    }

    internal void buttonDone_Click(object sender, EventArgs e)
    {
      if (this.buttonDone.Text == "&Connect")
      {
        try
        {
          tcpClient = GetTcpClient();

          if (this.textBoxInstrumentAddress.Text.Contains(":"))
          {
            string theoreticalPortString = this.textBoxInstrumentAddress.Text.Substring(this.textBoxInstrumentAddress.Text.IndexOf(":") + 1);
            int port = 0;
            bool success = int.TryParse(theoreticalPortString, out port);
            if (!success)
            {
              MessageBox.Show("Can't parse port");
              this.onDisconnected();
              return; 
            }
            string address = this.textBoxInstrumentAddress.Text.Substring(0, this.textBoxInstrumentAddress.Text.IndexOf(":"));
            tcpClient.Connect(address, port); 
          }
          else
          {
            tcpClient.Connect(this.textBoxInstrumentAddress.Text, 7777);
          }
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

      if (tcpClient.GetStream() != System.IO.Stream.Null)
      {
        try
        {
          tcpClient.GetStream().BeginRead(buffer, 0, 1024, callback, tcpClient);
        }
        catch (System.IO.IOException)
        {
          //normal
          this.textBoxInstrumentAddress.Enabled = true;
          this.buttonDone.Text = "&Connect";
          this.onDisconnected(); 
        }
      }
    }

    internal void textBoxInstrumentAddress_KeyUp(object sender, KeyEventArgs e)
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
