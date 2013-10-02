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
  public partial class SerialCommunicationUserControl : UserControl
  {
    public SerialCommunicationUserControl()
    {
      InitializeComponent();
    }

    public void Dispose()
    {
      if (this.serialPort != null && this.serialPort.IsOpen)
      {
        this.serialPort.Close();
        this.stopSerialPortRead = true; 
      }

      this.Dispose(true); 
    }

    private string serialPortName = string.Empty;

    private Action<Font, string> writeToListBox;
    public void Initialize(Action<Font, string> writeToListBox)
    {
      this.writeToListBox = writeToListBox; 

      object[] baudRates = { 115200, 57600, 56000, 38400, 28800, 19200, 14400, 9600, 4800, 2400, 1200, 600, 300, 110 };
      this.comboBoxBaudRate.Items.AddRange(baudRates);
      this.comboBoxBaudRate.SelectedItem = 57600;

      if (this.DesignMode == true)
        return;

      QuerySerialPorts();

      Properties.Settings.Default.ActiveRadioButton = "Serial";
      Properties.Settings.Default.Save();

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

    private bool stopSerialPortRead = true;
    private bool serialPortStopped = true;
    private ManualResetEvent serialPortReadSleep = new ManualResetEvent(false);
    private ManualResetEvent serialPortReadSleeped = new ManualResetEvent(false);

    private void ReadSerialPort(object uselessState)
    {
      stopSerialPortRead = false;
      serialPortStopped = false;
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
          MessageBox.Show("Read IO Error");
          this.Invoke(new Action(() => { this.QuerySerialPorts(); }));
          return;
          //Do some more nothing
        }
        catch (InvalidOperationException)
        {
          MessageBox.Show("Invalid Read");
          this.Invoke(new Action(() => { this.QuerySerialPorts(); }));
          return;
        }

        if (text != string.Empty)
        {

          this.Invoke(new Action(() => { writeToListBox(new Font("System", 10), text); }));
        }

        bool dataRead = serialPortReadSleep.WaitOne(300);
      }
      serialPortStopped = true;
    }

    private void comboBoxSerialPorts_SelectedIndexChanged(object sender, EventArgs e)
    {
      Debug.WriteLine(this.comboBoxSerialPorts.SelectedItem);

      if (this.comboBoxSerialPorts.SelectedItem.ToString() == "Refresh")
      {
        QuerySerialPorts();
        return;
      }

      if (serialPort != null)
      {
        StopReading();
      }

      serialPortName = this.comboBoxSerialPorts.SelectedItem.ToString();
      int baudRate = (int)this.comboBoxBaudRate.SelectedItem;
      serialPort = new System.IO.Ports.SerialPort(serialPortName, baudRate, System.IO.Ports.Parity.Odd, 7, System.IO.Ports.StopBits.One);
      serialPort.Handshake = Handshake.None;
      //serialPort = new System.IO.Ports.SerialPort(serialPortName, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);

      //serialPort.ReadTimeout = 200;
      try
      {
        serialPort.Open();
      }
      catch (IOException iex)
      {
        MessageBox.Show("Error opening port: " + serialPortName);
        return;
      }
      catch (UnauthorizedAccessException uaex)
      {
        MessageBox.Show("Error opening port: " + serialPortName);
        return;
      }

      System.Threading.ThreadPool.QueueUserWorkItem(ReadSerialPort, null);
    }
    private SerialPort serialPort;
    //private int baudRate = 9600;

    private void comboBoxBaudRate_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.serialPort == null)
      {
        return;
      }

      this.comboBoxSerialPorts_SelectedIndexChanged(null, null);
    }

    private void QuerySerialPorts()
    {
      this.comboBoxSerialPorts.Items.Clear();
      //this.buttonSend.Enabled = false;
      this.comboBoxSerialPorts.Enabled = false;
      //this.textBoxInput.Enabled = false;
      this.comboBoxBaudRate.Enabled = false;

      string[] portNames = System.IO.Ports.SerialPort.GetPortNames();

      if (portNames.Length == 0)
      {
        MessageBox.Show("No serial ports found!");
        this.buttonRefreshComPorts.Visible = true;
        return;
      }

      this.buttonRefreshComPorts.Visible = true;
      this.buttonRefreshComPorts.Focus();

      this.comboBoxSerialPorts.Enabled = true;
      //this.buttonSend.Enabled = true;
      List<string> sortedPortNamesList = portNames.ToList();
      sortedPortNamesList.Sort();
      this.comboBoxSerialPorts.Items.AddRange(sortedPortNamesList.ToArray());
      this.comboBoxSerialPorts.Items.Add("Refresh");
      //this.textBoxInput.Enabled = true;
      this.comboBoxBaudRate.Enabled = true;
      this.buttonRefreshComPorts.Visible = false;

      this.comboBoxSerialPorts.SelectedIndex = 0;
    }

    private void buttonRefreshComPorts_Click(object sender, EventArgs e)
    {
      this.QuerySerialPorts();
    }

    public void Write(string input)
    {
      try
      {
        this.serialPort.Write(input);
      }
      catch (TimeoutException tex)
      {
        MessageBox.Show("Write timeout");
        //this.QuerySerialPorts();
        return;
      }
      catch (IOException iex)
      {
        MessageBox.Show("IO Exception ");
        //this.QuerySerialPorts();
        return;
      }

    }
  }
}
