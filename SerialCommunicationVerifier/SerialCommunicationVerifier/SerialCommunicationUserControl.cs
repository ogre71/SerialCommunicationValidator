using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO.Ports;
using System.IO;

namespace SerialCommunicationVerifier
{

  public partial class SerialCommunicationUserControl : CommunicationUserControl
  {
    internal interface ISerialPort
    {
      void Write(string message);
      int BytesToRead { get;  }
      bool IsOpen { get;  }
      void Close();
      int ReadByte();
      void Open(); 
    }

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    private class RealSerialPort : ISerialPort
    {
      private SerialPort serialPort; 
      public RealSerialPort(SerialPort serialPort)
      {
        this.serialPort = serialPort; 
      }

      public void Write(string message)
      {
        this.serialPort.Write(message); 
      }

      public int BytesToRead
      {
        get 
        {
          return this.serialPort.BytesToRead;
        }
      }

      public bool IsOpen
      {
        get
        {
          return this.serialPort.IsOpen;
        }
      }

      public void Close()
      {
        this.serialPort.Close(); 
      }

      public int ReadByte()
      {
        return this.serialPort.ReadByte(); 
      }

      public void Open()
      {
        this.serialPort.Open(); 
      }
    }

    private string serialPortName = string.Empty;

    private bool stopSerialPortRead = true;
    private ManualResetEvent serialPortReadSleep = new ManualResetEvent(false);
    private ManualResetEvent serialPortReadSleeped = new ManualResetEvent(false);
    //private Button buttonDone; 

    private ISerialPort serialPort;

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public SerialCommunicationUserControl() : base(null, null, null)
    {
      InitializeComponent();
    }

    public SerialCommunicationUserControl(Action<Font, string> writeToListBox, Action onConnected, Action onDisconnected, Button buttonDone) : base(writeToListBox, onConnected, onDisconnected)
    {
      InitializeComponent();

      base.writeToListBox = writeToListBox;

      object[] baudRates = { 115200, 57600, /*56000,*/ 38400, 28800, 19200, 14400, 9600,/* 4800, 2400,*/ 1200 /*, 600, 300, 110*/ };
      this.comboBoxBaudRate.Items.AddRange(baudRates);
      

      this.QuerySerialPorts();

      Properties.Settings.Default.ActiveRadioButton = "Serial";
      Properties.Settings.Default.Save();

      if (!string.IsNullOrEmpty(Properties.Settings.Default.BaudRate))
      {
        string baudRateString = Properties.Settings.Default.BaudRate;
        this.comboBoxBaudRate.SelectedItem = int.Parse(baudRateString);
      }
      else
      {
        this.comboBoxBaudRate.SelectedItem = 57600;
      }
    }

    internal SerialCommunicationUserControl(Action<Font, string> writeToListBox, Action onConnected, Action onDisconnected, Button buttonDone, ISerialPort serialPort)
      : this(writeToListBox, onConnected, onDisconnected, buttonDone)
    {
      this.serialPort = serialPort; 
    }

    private void StopReading()
    {
      if (serialPort.IsOpen)
      {
        serialPort.Close();
      }

      stopSerialPortRead = true;
      serialPortReadSleep.Set();
      serialPortReadSleeped.WaitOne(TimeSpan.FromMilliseconds(300));
    }

    private void ReadSerialPort(object uselessState)
    {
      stopSerialPortRead = false;
      serialPortReadSleep.Reset();

      while (!stopSerialPortRead)
      {
        string text = string.Empty;
        try
        {
          string buffer = string.Empty;
          while (serialPort.BytesToRead > 0)
          {
            int thisByte = serialPort.ReadByte();
            buffer = buffer + (char)thisByte;
          }
          text = buffer;
        }
        catch (TimeoutException)
        {
          //Do nothing this is normal!  
        }
        catch (IOException)
        {
          //MessageBox.Show("Read IO Error");
          resetBecauseOfError(); 
          return;
          //Do some more nothing
        }
        catch (InvalidOperationException)
        {
          //MessageBox.Show("Invalid Read");
          resetBecauseOfError(); 
          return;
        }

        if (text != string.Empty)
        {

          this.Invoke(new Action<Font, string>(this.writeToListBox), new Font("System", 10), text);
        }

        bool dataRead = serialPortReadSleep.WaitOne(300);
      }
    }

    internal void resetBecauseOfError()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(this.resetBecauseOfError));
        return; 
      }

      this.connected = false; 
      this.onDisconnected();
      this.QuerySerialPorts();
      this.comboBoxSerialPorts.Enabled = true;
      this.comboBoxBaudRate.Enabled = true;
    }

    private void QuerySerialPorts()
    {
      this.comboBoxSerialPorts.Items.Clear();
      //this.buttonSend.Enabled = false;
      //this.comboBoxSerialPorts.Enabled = false;
      //this.textBoxInput.Enabled = false;
      this.comboBoxBaudRate.Enabled = false;

      string[] portNames = System.IO.Ports.SerialPort.GetPortNames();

      if (portNames.Length == 0)
      {
        //MessageBox.Show("No serial ports found!");
        //this.buttonRefreshComPorts.Visible = true;
        this.comboBoxSerialPorts.Items.Add("Refresh");
        this.onDisconnected(); 
        return;
      }

      this.comboBoxSerialPorts.Enabled = true;
      //this.buttonSend.Enabled = true;
      List<string> sortedPortNamesList = portNames.ToList();
      sortedPortNamesList.Sort();
      this.comboBoxSerialPorts.Items.AddRange(sortedPortNamesList.ToArray());
      this.comboBoxSerialPorts.Items.Add("Refresh");
      //this.textBoxInput.Enabled = true;
      this.comboBoxBaudRate.Enabled = true;
      //this.buttonRefreshComPorts.Visible = false;

      this.comboBoxSerialPorts.SelectedIndex = 0;
    }

    internal void buttonRefreshComPorts_Click(object sender, EventArgs e)
    {

    }

    public override void Write(string input)
    {
      try
      {
        this.serialPort.Write(input);
      }
      catch (TimeoutException)
      {
        this.resetBecauseOfError();
        return;
      }
      catch (InvalidOperationException)
      {
        this.resetBecauseOfError();
        return; 
      }
      catch (IOException)
      {
        this.resetBecauseOfError();
        return;
      }
    }

    public override void Close()
    {
      if (this.serialPort != null && this.serialPort.IsOpen)
      {
        this.serialPort.Close();
        this.stopSerialPortRead = true;
      }

      this.Dispose(true);
    }

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    private ISerialPort GetSerialPort()
    {
      // If we're mocking the serial port... just leave it. 
      if (this.serialPort != null && !(this.serialPort is RealSerialPort))
      {
        return this.serialPort; 
      }

      if (this.comboBoxSerialPorts.SelectedItem == null)
      {
        return null; 
      }

      serialPortName = this.comboBoxSerialPorts.SelectedItem.ToString();
      int baudRate = (int)this.comboBoxBaudRate.SelectedItem;
      return new RealSerialPort(new System.IO.Ports.SerialPort(serialPortName, baudRate, System.IO.Ports.Parity.Odd, 7, System.IO.Ports.StopBits.One));
    }

    bool connected = false; 

    internal override bool ToggleConnect()
    {

      if (!this.connected)
      {
        Debug.WriteLine(this.comboBoxSerialPorts.SelectedItem);

        //if (this.comboBoxSerialPorts.SelectedItem.ToString() == "Refresh")
        //{
        //  this.QuerySerialPorts();
        //  return;
        //}

        if (serialPort != null)
        {
          StopReading();
        }

        //serialPortName = this.comboBoxSerialPorts.SelectedItem.ToString();
        //int baudRate = (int)this.comboBoxBaudRate.SelectedItem;
        serialPort = GetSerialPort(); // new RealSerialPort(new System.IO.Ports.SerialPort(serialPortName, baudRate, System.IO.Ports.Parity.Odd, 7, System.IO.Ports.StopBits.One));
        //serialPort.Handshake = Handshake.None;

        if (serialPort == null)
        {
          return false; 
        }

        try
        {
          serialPort.Open();
        }
        catch (IOException)
        {
          MessageBox.Show("Error opening port: " + serialPortName);
          this.QuerySerialPorts(); 
          return false;
        }
        catch (UnauthorizedAccessException)
        {
          MessageBox.Show("Error opening port: " + serialPortName);
          this.QuerySerialPorts(); 
          return false;
        }

        System.Threading.ThreadPool.QueueUserWorkItem(ReadSerialPort, null);
        this.comboBoxBaudRate.Enabled = false;
        this.comboBoxSerialPorts.Enabled = false;

        this.connected = true; 
        this.onConnected();
        return true; 
      }
      else
      {
        if (this.serialPort != null)
        {
          this.StopReading();
          this.serialPort.Close();
        }

        this.comboBoxBaudRate.Enabled = true;
        this.comboBoxSerialPorts.Enabled = true;
        this.connected = false; 
        this.onDisconnected();
        return false; 
      }
    }

    private void comboBoxSerialPorts_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (comboBoxSerialPorts.SelectedItem == "Refresh")
      {
        this.QuerySerialPorts();
        if (this.serialPort != null && this.serialPort.IsOpen)
        {
          this.comboBoxSerialPorts.Enabled = false;
          this.comboBoxBaudRate.Enabled = false;
        }

        return; 
      }
    }

    private void comboBoxBaudRate_SelectedIndexChanged(object sender, EventArgs e)
    {
      string baudRateString = this.comboBoxBaudRate.SelectedItem.ToString();
      Properties.Settings.Default.BaudRate = baudRateString;
      Properties.Settings.Default.Save(); 
    }

  }
}
