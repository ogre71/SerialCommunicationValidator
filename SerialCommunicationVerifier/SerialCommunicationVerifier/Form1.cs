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

namespace SerialCommunicationVerifier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBoxSerialPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(this.comboBoxSerialPorts.SelectedText); 
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuerySerialPorts()
        {
            this.comboBoxSerialPorts.Items.Clear();
            this.buttonSend.Enabled = false;
            this.comboBoxSerialPorts.Enabled = false;
            this.textBoxInput.Enabled = false;
            this.comboBoxBaudRate.Enabled = false; 

            string[] portNames = System.IO.Ports.SerialPort.GetPortNames();

            if (portNames.Length == 0)
            {
                MessageBox.Show("No serial ports found!");
                return;
            }

            this.buttonRefreshComPorts.Visible = true;
            this.buttonRefreshComPorts.Focus(); 

            this.comboBoxSerialPorts.Enabled = true;
            this.buttonSend.Enabled = true;
            this.comboBoxSerialPorts.Items.AddRange(portNames);
            this.textBoxInput.Enabled = true;
            this.comboBoxBaudRate.Enabled = true;
            this.buttonRefreshComPorts.Visible = false; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            QuerySerialPorts(); 
        }

        private void buttonRefreshComPorts_Click(object sender, EventArgs e)
        {
            this.QuerySerialPorts(); 
        }
    }
}
