using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using System.IO; 

namespace SerialCommunicationVerifier
{
  public partial class Form1 : Form
  {
    private Stack<string> keyLog = new Stack<string>();
    private int stackIndex = 0;
    private Action<string> write; 

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      if (Properties.Settings.Default.ActiveRadioButton == "Serial")
      {
        this.radioButtonSerial.Checked = true;
      }
      else
      {
        this.radioButtonTcpIp.Checked = true; 
      }

      ThreadPool.QueueUserWorkItem(new WaitCallback((object ob) => { this.radioButtonSerial_CheckedChanged(null, null); }));
    }

    private void buttonSend_Click(object sender, EventArgs e)
    {
      this.write(this.textBoxInput.Text + "\r\n");

      Font font = new System.Drawing.Font("System", 10, FontStyle.Italic);
      ListViewItem listViewItem = this.listView1.Items.Add(new ListViewItem(new string[] { this.textBoxInput.Text }, 0, System.Drawing.Color.Black, System.Drawing.Color.White, font));
      listViewItem.EnsureVisible();
      this.textBoxInput.Clear(); 
    }

    private void buttonId_Click(object sender, EventArgs e)
    {
      if (this.textBoxInput.Text != string.Empty)
      {
        this.buttonSend_Click(null, null); 
      }

      this.textBoxInput.Text = "*idn?";
      this.buttonSend_Click(null, null); 
    }

    private void clearToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.listView1.Items.Clear();
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      this.columnHeader1.Width = this.listView1.Width;
      this.listView1.HeaderStyle = ColumnHeaderStyle.None;
    }

    private void radioButtonSerial_CheckedChanged(object sender, EventArgs e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action( () => { this.radioButtonSerial_CheckedChanged(sender, e); }));
        return; 
      }

      if (this.radioButtonSerial.Checked == true)
      {
        SerialCommunicationUserControl uc = new SerialCommunicationUserControl(this.WriteToListView, this.OnConnected, this.OnDisconnected);
        SwapUserControl(uc); 
      }
      else
      {
        TcpIpCommunicationUserControl uc = new TcpIpCommunicationUserControl(this.WriteToListView, this.OnConnected, this.OnDisconnected);
        this.SwapUserControl(uc); 
      }
    }

    internal void SwapUserControl(CommunicationUserControl newUserControl)
    {
      if (this.groupBox1.Controls.Count > 0)
      { 
        CommunicationUserControl currentUserControl = (CommunicationUserControl) this.groupBox1.Controls[0];
        currentUserControl.Close(); 

        this.groupBox1.Controls.Clear();
      }

      this.OnDisconnected(); 

      this.groupBox1.Controls.Add(newUserControl);
      newUserControl.Dock = DockStyle.Fill;
      newUserControl.Show();
      this.write = newUserControl.Write;
    }

    internal void WriteToListView(Font font, string text)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() => { this.WriteToListView(font, text); }));
        return; 
      }

      ListViewItem listViewItem = this.listView1.Items.Add(new ListViewItem(new string[] { text }, 0, System.Drawing.Color.Black, System.Drawing.Color.White, font));
      listViewItem.EnsureVisible();
    }

    internal void OnConnected()
    {
      this.textBoxInput.Enabled = true;
      this.buttonSend.Enabled = true;
      this.buttonId.Enabled = true;

      this.textBoxInput.Focus(); 
    }

    internal void OnDisconnected()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(OnDisconnected)); 
        return; 
      }
      this.textBoxInput.Enabled = false;
      this.buttonSend.Enabled = false;
      this.buttonId.Enabled = false; 
    }

    private void textBoxInput_KeyUp(object sender, KeyEventArgs e)
    {
      if ((char)e.KeyCode == '\r')
      {
        if (textBoxInput.Text == string.Empty)
        {
          return;
        }

        stackIndex = 0;
        keyLog.Push(textBoxInput.Text);
        
        this.buttonSend_Click(null, null);
      }
      else if (e.KeyData == Keys.Up)
      {
        if (keyLog.Count == 0)
        {
          return; 
        }

        stackIndex++;
        if (stackIndex > keyLog.Count - 1)
        {
          stackIndex = keyLog.Count - 1;
        }

        textBoxInput.Text = keyLog.ElementAt(stackIndex);
      }
      else if (e.KeyData == Keys.Down)
      {
        stackIndex--;
        if (stackIndex < 0)
        {
          stackIndex = 0;
          return;
        }

        textBoxInput.Text = keyLog.ElementAt(stackIndex);
      }
    }

    internal void TestFlipSerialRadioButtons()
    {
      this.radioButtonSerial.Checked = !this.radioButtonSerial.Checked;
    }

    internal void TestTextBoxInput(KeyEventArgs e)
    {
      this.textBoxInput_KeyUp(null, e); 
    }
  }
}
