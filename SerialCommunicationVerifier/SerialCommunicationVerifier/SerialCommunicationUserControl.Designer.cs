namespace SerialCommunicationVerifier
{
  partial class SerialCommunicationUserControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.buttonRefreshComPorts = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.comboBox5 = new System.Windows.Forms.ComboBox();
      this.comboBox4 = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.comboBox3 = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBoxSerialPorts = new System.Windows.Forms.ComboBox();
      this.buttonDone = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // buttonRefreshComPorts
      // 
      this.buttonRefreshComPorts.Location = new System.Drawing.Point(6, 16);
      this.buttonRefreshComPorts.Name = "buttonRefreshComPorts";
      this.buttonRefreshComPorts.Size = new System.Drawing.Size(121, 23);
      this.buttonRefreshComPorts.TabIndex = 25;
      this.buttonRefreshComPorts.Text = "Refresh COM Ports";
      this.buttonRefreshComPorts.UseVisualStyleBackColor = true;
      this.buttonRefreshComPorts.Click += new System.EventHandler(this.buttonRefreshComPorts_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(587, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(50, 13);
      this.label5.TabIndex = 24;
      this.label5.Text = "Data Bits";
      // 
      // comboBox5
      // 
      this.comboBox5.Enabled = false;
      this.comboBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.comboBox5.FormattingEnabled = true;
      this.comboBox5.Location = new System.Drawing.Point(590, 16);
      this.comboBox5.Name = "comboBox5";
      this.comboBox5.Size = new System.Drawing.Size(121, 21);
      this.comboBox5.TabIndex = 23;
      // 
      // comboBox4
      // 
      this.comboBox4.Enabled = false;
      this.comboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.comboBox4.FormattingEnabled = true;
      this.comboBox4.Location = new System.Drawing.Point(442, 16);
      this.comboBox4.Name = "comboBox4";
      this.comboBox4.Size = new System.Drawing.Size(121, 21);
      this.comboBox4.TabIndex = 22;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(439, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(49, 13);
      this.label4.TabIndex = 21;
      this.label4.Text = "Stop Bits";
      // 
      // comboBox3
      // 
      this.comboBox3.Enabled = false;
      this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.comboBox3.FormattingEnabled = true;
      this.comboBox3.Location = new System.Drawing.Point(295, 16);
      this.comboBox3.Name = "comboBox3";
      this.comboBox3.Size = new System.Drawing.Size(121, 21);
      this.comboBox3.TabIndex = 20;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(292, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(33, 13);
      this.label3.TabIndex = 19;
      this.label3.Text = "Parity";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(147, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(61, 13);
      this.label2.TabIndex = 18;
      this.label2.Text = "Baud Rate:";
      // 
      // comboBoxBaudRate
      // 
      this.comboBoxBaudRate.Enabled = false;
      this.comboBoxBaudRate.FormattingEnabled = true;
      this.comboBoxBaudRate.Location = new System.Drawing.Point(150, 16);
      this.comboBoxBaudRate.Name = "comboBoxBaudRate";
      this.comboBoxBaudRate.Size = new System.Drawing.Size(121, 21);
      this.comboBoxBaudRate.TabIndex = 17;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(56, 13);
      this.label1.TabIndex = 16;
      this.label1.Text = "COM Port:";
      // 
      // comboBoxSerialPorts
      // 
      this.comboBoxSerialPorts.FormattingEnabled = true;
      this.comboBoxSerialPorts.Location = new System.Drawing.Point(6, 16);
      this.comboBoxSerialPorts.Name = "comboBoxSerialPorts";
      this.comboBoxSerialPorts.Size = new System.Drawing.Size(121, 21);
      this.comboBoxSerialPorts.TabIndex = 15;
      this.comboBoxSerialPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerialPorts_SelectedIndexChanged);
      // 
      // buttonDone
      // 
      this.buttonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonDone.Location = new System.Drawing.Point(643, 47);
      this.buttonDone.Name = "buttonDone";
      this.buttonDone.Size = new System.Drawing.Size(75, 23);
      this.buttonDone.TabIndex = 26;
      this.buttonDone.Text = "&Done";
      this.buttonDone.UseVisualStyleBackColor = true;
      // 
      // SerialCommunicationUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.buttonDone);
      this.Controls.Add(this.buttonRefreshComPorts);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.comboBox5);
      this.Controls.Add(this.comboBox4);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.comboBox3);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.comboBoxBaudRate);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.comboBoxSerialPorts);
      this.Name = "SerialCommunicationUserControl";
      this.Size = new System.Drawing.Size(721, 73);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonRefreshComPorts;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox comboBox5;
    private System.Windows.Forms.ComboBox comboBox4;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox comboBox3;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox comboBoxBaudRate;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBoxSerialPorts;
    private System.Windows.Forms.Button buttonDone;

  }
}
