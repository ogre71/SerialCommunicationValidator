﻿namespace SerialCommunicationVerifier
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.textBoxInput = new System.Windows.Forms.TextBox();
      this.buttonSend = new System.Windows.Forms.Button();
      this.listView1 = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.buttonId = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.radioButtonSerial = new System.Windows.Forms.RadioButton();
      this.radioButtonTcpIp = new System.Windows.Forms.RadioButton();
      this.buttonDone = new System.Windows.Forms.Button();
      this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // textBoxInput
      // 
      this.textBoxInput.AcceptsTab = true;
      this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxInput.Location = new System.Drawing.Point(12, 442);
      this.textBoxInput.Name = "textBoxInput";
      this.textBoxInput.Size = new System.Drawing.Size(637, 20);
      this.textBoxInput.TabIndex = 1;
      this.textBoxInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxInput_KeyUp);
      // 
      // buttonSend
      // 
      this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonSend.Enabled = false;
      this.buttonSend.Location = new System.Drawing.Point(658, 439);
      this.buttonSend.Name = "buttonSend";
      this.buttonSend.Size = new System.Drawing.Size(75, 23);
      this.buttonSend.TabIndex = 5;
      this.buttonSend.Text = "Send";
      this.buttonSend.UseVisualStyleBackColor = true;
      this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
      // 
      // listView1
      // 
      this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
      this.listView1.ContextMenuStrip = this.contextMenuStrip1;
      this.listView1.FullRowSelect = true;
      this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.listView1.HideSelection = false;
      this.listView1.HoverSelection = true;
      this.listView1.Location = new System.Drawing.Point(15, 118);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(718, 283);
      this.listView1.TabIndex = 15;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "";
      this.columnHeader1.Width = 713;
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.selectAllToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
      // 
      // clearToolStripMenuItem
      // 
      this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
      this.clearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.clearToolStripMenuItem.Text = "c&lear";
      this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
      // 
      // buttonId
      // 
      this.buttonId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonId.Enabled = false;
      this.buttonId.Location = new System.Drawing.Point(658, 410);
      this.buttonId.Name = "buttonId";
      this.buttonId.Size = new System.Drawing.Size(75, 23);
      this.buttonId.TabIndex = 16;
      this.buttonId.Text = "ID";
      this.buttonId.UseVisualStyleBackColor = true;
      this.buttonId.Click += new System.EventHandler(this.buttonId_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Location = new System.Drawing.Point(93, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(640, 100);
      this.groupBox1.TabIndex = 19;
      this.groupBox1.TabStop = false;
      // 
      // radioButtonSerial
      // 
      this.radioButtonSerial.AutoSize = true;
      this.radioButtonSerial.Checked = true;
      this.radioButtonSerial.Location = new System.Drawing.Point(15, 13);
      this.radioButtonSerial.Name = "radioButtonSerial";
      this.radioButtonSerial.Size = new System.Drawing.Size(51, 17);
      this.radioButtonSerial.TabIndex = 20;
      this.radioButtonSerial.TabStop = true;
      this.radioButtonSerial.Text = "Serial";
      this.radioButtonSerial.UseVisualStyleBackColor = true;
      this.radioButtonSerial.CheckedChanged += new System.EventHandler(this.radioButtonSerial_CheckedChanged);
      // 
      // radioButtonTcpIp
      // 
      this.radioButtonTcpIp.AutoSize = true;
      this.radioButtonTcpIp.Location = new System.Drawing.Point(15, 36);
      this.radioButtonTcpIp.Name = "radioButtonTcpIp";
      this.radioButtonTcpIp.Size = new System.Drawing.Size(61, 17);
      this.radioButtonTcpIp.TabIndex = 21;
      this.radioButtonTcpIp.Text = "TCP/IP";
      this.radioButtonTcpIp.UseVisualStyleBackColor = true;
      // 
      // buttonDone
      // 
      this.buttonDone.Location = new System.Drawing.Point(15, 60);
      this.buttonDone.Name = "buttonDone";
      this.buttonDone.Size = new System.Drawing.Size(75, 23);
      this.buttonDone.TabIndex = 22;
      this.buttonDone.Text = "&Connect";
      this.buttonDone.UseVisualStyleBackColor = true;
      this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
      // 
      // copyToolStripMenuItem
      // 
      this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
      this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.copyToolStripMenuItem.Text = "&copy";
      this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
      // 
      // selectAllToolStripMenuItem
      // 
      this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
      this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.selectAllToolStripMenuItem.Text = "select &all";
      this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(742, 474);
      this.Controls.Add(this.buttonDone);
      this.Controls.Add(this.radioButtonTcpIp);
      this.Controls.Add(this.radioButtonSerial);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.buttonId);
      this.Controls.Add(this.listView1);
      this.Controls.Add(this.buttonSend);
      this.Controls.Add(this.textBoxInput);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(400, 300);
      this.Name = "Form1";
      this.Text = "Lake Shore Instrument Communication Utility version 0.1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.Resize += new System.EventHandler(this.Form1_Resize);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox textBoxInput;
        internal System.Windows.Forms.Button buttonSend;
        internal System.Windows.Forms.ListView listView1;
        internal System.Windows.Forms.Button buttonId;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSerial;
        private System.Windows.Forms.RadioButton radioButtonTcpIp;
        internal System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    }
}

