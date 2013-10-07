using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerialCommunicationVerifier;
using System.Drawing;
using System.Collections.Generic;

namespace CommunicationUtilityUnitTestProject
{
  [TestClass]
  public class UnitTest1
  {

    public class FakeCommunicationUserControl : CommunicationUserControl
    {
      private Action<Font, string> writeToOutputControl; 

      public FakeCommunicationUserControl(Action<Font, string> writeToOutputControl, Action onConnected, Action onDisconnected) : base (writeToOutputControl, onConnected, onDisconnected)
      {
        this.writeToOutputControl = writeToOutputControl;
      }

      public override void Write(string message)
      {
      }

      public override void Close()
      {
        this.onDisconnected(); 
      }

      public void Connect()
      {
        this.onConnected(); 
      }

      public void WriteToListView(string message)
      {
        this.writeToOutputControl(new Font("System", 14), message);
      }
    }

    [TestMethod]
    public void TestShowForm()
    {
      Form1 form1 = new Form1();
      form1.Show();
      form1.Dispose(); 
    }

    [TestMethod]
    public void TestClickRadioButtons()
    {
      Form1 form1 = new Form1();
      form1.TestFlipSerialRadioButtons();
      form1.TestFlipSerialRadioButtons();
    }

    [TestMethod]
    public void TestHistoryRecall()
    {
      Form1 form1 = new Form1();

      form1.SwapUserControl(new FakeCommunicationUserControl(null, null, null));

      form1.textBoxInput.Text = "cheese";
      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Enter));

      form1.textBoxInput.Text = "squid";
      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Enter));

      form1.textBoxInput.Text = "fruit bats";
      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Enter));

      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Up));

      Assert.IsTrue(form1.textBoxInput.Text == "fruit bats");

      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Up));

      Assert.IsTrue(form1.textBoxInput.Text == "squid");

      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Down));

      Assert.IsTrue(form1.textBoxInput.Text == "fruit bats");

      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Up));
      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Up));

      Assert.IsTrue(form1.textBoxInput.Text == "cheese");

      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Up));
      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Up));
      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Up));

      Assert.IsTrue(form1.textBoxInput.Text == "cheese");

      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Down));

      Assert.IsTrue(form1.textBoxInput.Text == "squid");

      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Down));
      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Down));
      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Down));
      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Down));
      form1.TestTextBoxInput(new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Down));

      Assert.IsTrue(form1.textBoxInput.Text == "fruit bats"); 
    }

    [TestMethod]
    public void TestConnectEnablesTextBoxInput()
    {
      Form1 form1 = new Form1();
      FakeCommunicationUserControl fake = new FakeCommunicationUserControl(form1.WriteToListView, form1.OnConnected, form1.OnDisconnected);
      form1.SwapUserControl(fake);

      Assert.IsFalse(form1.textBoxInput.Enabled);
      Assert.IsFalse(form1.buttonSend.Enabled);
      Assert.IsFalse(form1.buttonId.Enabled);

      fake.Connect();

      Assert.IsTrue(form1.textBoxInput.Enabled);
      Assert.IsTrue(form1.buttonSend.Enabled);
      Assert.IsTrue(form1.buttonId.Enabled);

      fake.Close();

      Assert.IsFalse(form1.textBoxInput.Enabled);
      Assert.IsFalse(form1.buttonSend.Enabled);
      Assert.IsFalse(form1.buttonId.Enabled);
    }

    [TestMethod]
    public void TestConnectWriteToListView()
    {
      Form1 form1 = new Form1();
      FakeCommunicationUserControl fake = new FakeCommunicationUserControl(form1.WriteToListView, form1.OnConnected, form1.OnDisconnected);
      form1.SwapUserControl(fake);

      fake.WriteToListView("All work and no play makes Johnny a dull boy.");

      Assert.IsTrue(form1.listView1.Items[0].Text == "All work and no play makes Johnny a dull boy.");
    }

    internal class MockishSerialPort : SerialCommunicationUserControl.ISerialPort
    {
      public void Write(string message)
      {
      }

      public int BytesToRead
      {
        get { return 0; }
      }

      public bool IsOpen
      {
        get 
        {
          return true; 
        }
      }

      public void Close()
      {
      }

      public int ReadByte()
      {
        return 7; 
      }

      public void Open()
      {
      }
    }

    [TestMethod]
    public void TestSerialCommunicationUserControl1()
    {
      Form1 form1 = new Form1();
      MockishSerialPort mockishSerialPort = new MockishSerialPort();
      SerialCommunicationUserControl fakeSerialCommunicationUserControl = new SerialCommunicationUserControl(form1.WriteToListView, form1.OnConnected, form1.OnDisconnected, form1.buttonDone, mockishSerialPort);
      form1.SwapUserControl(fakeSerialCommunicationUserControl);

      fakeSerialCommunicationUserControl.ToggleConnect();
      fakeSerialCommunicationUserControl.Write("Cheese!");
      fakeSerialCommunicationUserControl.buttonRefreshComPorts_Click(null, null); 
      fakeSerialCommunicationUserControl.ToggleConnect();
      fakeSerialCommunicationUserControl.resetBecauseOfError();

      form1.Show(); 

      fakeSerialCommunicationUserControl.Close(); 
    }

    [TestMethod]
    public void TestBaudRateIsSaved()
    {
      Form1 form1 = new Form1();
      MockishSerialPort mockishSerialPort = new MockishSerialPort();
      SerialCommunicationUserControl fakeSerialCommunicationUserControl = new SerialCommunicationUserControl(form1.WriteToListView, form1.OnConnected, form1.OnDisconnected, form1.buttonDone, mockishSerialPort);
      form1.SwapUserControl(fakeSerialCommunicationUserControl);

      fakeSerialCommunicationUserControl.comboBoxBaudRate.SelectedItem = 9600;

      Form1 form2 = new Form1();
      MockishSerialPort mockishSerialPort2 = new MockishSerialPort();
      SerialCommunicationUserControl fakeSerialCommunicationUserControl2 = new SerialCommunicationUserControl(form2.WriteToListView, form2.OnConnected, form2.OnDisconnected, form2.buttonDone, mockishSerialPort2);
      form2.SwapUserControl(fakeSerialCommunicationUserControl2);

      Assert.IsTrue((int)fakeSerialCommunicationUserControl2.comboBoxBaudRate.SelectedItem == 9600);
      fakeSerialCommunicationUserControl2.comboBoxBaudRate.SelectedItem = 14400;

      Form1 form3 = new Form1();
      MockishSerialPort mockishSerialPort3 = new MockishSerialPort();
      SerialCommunicationUserControl fakeSerialCommunicationUserControl3 = new SerialCommunicationUserControl(form3.WriteToListView, form3.OnConnected, form3.OnDisconnected, form3.buttonDone, mockishSerialPort3);
      form3.SwapUserControl(fakeSerialCommunicationUserControl3);

      Assert.IsTrue((int)fakeSerialCommunicationUserControl3.comboBoxBaudRate.SelectedItem == 14400);
      
    }

    internal class MockishTcpIpClient : TcpIpCommunicationUserControl.ITcpClient
    {
      public int ReceiveTimeout
      {
        get
        {
          throw new NotImplementedException();
        }
        set
        {
          throw new NotImplementedException();
        }
      }

      public void Connect(string address, int port)
      {
      }

      public System.IO.Stream GetStream()
      {
        return System.IO.Stream.Null; 
      }

      public bool Connected
      {
        get { return true;  }
      }

      public void Close()
      {
      }
    }


    [TestMethod]
    public void TestTcpIpCommunicationUserControl1()
    {
      Form1 form1 = new Form1();
      MockishTcpIpClient mockishTcpIpClient = new MockishTcpIpClient();
      TcpIpCommunicationUserControl fakeTcpIpCommunicationUserControl = new TcpIpCommunicationUserControl(form1.WriteToListView, form1.OnConnected, form1.OnDisconnected, form1.buttonDone, mockishTcpIpClient);
      form1.SwapUserControl(fakeTcpIpCommunicationUserControl);
      fakeTcpIpCommunicationUserControl.ToggleConnect();
      fakeTcpIpCommunicationUserControl.Write("Cheese!");

      fakeTcpIpCommunicationUserControl.textBoxInstrumentAddress.Text = "Cheese!";
      fakeTcpIpCommunicationUserControl.textBoxInstrumentAddress_KeyUp(null, new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Enter));

      fakeTcpIpCommunicationUserControl.textBoxInstrumentAddress.Text = "Cheese:7799";
      fakeTcpIpCommunicationUserControl.textBoxInstrumentAddress_KeyUp(null, new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Enter));

      //fakeTcpIpCommunicationUserControl.buttonRefreshComPorts_Click(null, null);
      //fakeTcpIpCommunicationUserControl.buttonDone_Click(null, null);
      //fakeTcpIpCommunicationUserControl.resetBecauseOfError();

      //form1.Show();

      //fakeTcpIpCommunicationUserControl.Close();
    }
  }
}
