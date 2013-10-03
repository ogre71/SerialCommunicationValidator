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
      this.labelDataBitsLabel = new System.Windows.Forms.Label();
      this.labelStopBitsLabel = new System.Windows.Forms.Label();
      this.labelParityLabel = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBoxSerialPorts = new System.Windows.Forms.ComboBox();
      this.buttonDone = new System.Windows.Forms.Button();
      this.labelParity = new System.Windows.Forms.Label();
      this.labelStopBits = new System.Windows.Forms.Label();
      this.labelDataBits = new System.Windows.Forms.Label();
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
      // labelDataBitsLabel
      // 
      this.labelDataBitsLabel.AutoSize = true;
      this.labelDataBitsLabel.Location = new System.Drawing.Point(291, 46);
      this.labelDataBitsLabel.Name = "labelDataBitsLabel";
      this.labelDataBitsLabel.Size = new System.Drawing.Size(53, 13);
      this.labelDataBitsLabel.TabIndex = 24;
      this.labelDataBitsLabel.Text = "Data Bits:";
      // 
      // labelStopBitsLabel
      // 
      this.labelStopBitsLabel.AutoSize = true;
      this.labelStopBitsLabel.Location = new System.Drawing.Point(292, 23);
      this.labelStopBitsLabel.Name = "labelStopBitsLabel";
      this.labelStopBitsLabel.Size = new System.Drawing.Size(52, 13);
      this.labelStopBitsLabel.TabIndex = 21;
      this.labelStopBitsLabel.Text = "Stop Bits:";
      // 
      // labelParityLabel
      // 
      this.labelParityLabel.AutoSize = true;
      this.labelParityLabel.Location = new System.Drawing.Point(308, 0);
      this.labelParityLabel.Name = "labelParityLabel";
      this.labelParityLabel.Size = new System.Drawing.Size(36, 13);
      this.labelParityLabel.TabIndex = 19;
      this.labelParityLabel.Text = "Parity:";
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
      this.buttonDone.Location = new System.Drawing.Point(411, 47);
      this.buttonDone.Name = "buttonDone";
      this.buttonDone.Size = new System.Drawing.Size(75, 23);
      this.buttonDone.TabIndex = 26;
      this.buttonDone.Text = "&Connect";
      this.buttonDone.UseVisualStyleBackColor = true;
      this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
      // 
      // labelParity
      // 
      this.labelParity.AutoSize = true;
      this.labelParity.Location = new System.Drawing.Point(340, 0);
      this.labelParity.Name = "labelParity";
      this.labelParity.Size = new System.Drawing.Size(33, 13);
      this.labelParity.TabIndex = 27;
      this.labelParity.Text = "Parity";
      // 
      // labelStopBits
      // 
      this.labelStopBits.AutoSize = true;
      this.labelStopBits.Location = new System.Drawing.Point(340, 23);
      this.labelStopBits.Name = "labelStopBits";
      this.labelStopBits.Size = new System.Drawing.Size(49, 13);
      this.labelStopBits.TabIndex = 28;
      this.labelStopBits.Text = "Stop Bits";
      // 
      // labelDataBits
      // 
      this.labelDataBits.AutoSize = true;
      this.labelDataBits.Location = new System.Drawing.Point(340, 46);
      this.labelDataBits.Name = "labelDataBits";
      this.labelDataBits.Size = new System.Drawing.Size(50, 13);
      this.labelDataBits.TabIndex = 29;
      this.labelDataBits.Text = "Data Bits";
      // 
      // SerialCommunicationUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.labelDataBits);
      this.Controls.Add(this.labelStopBits);
      this.Controls.Add(this.labelParity);
      this.Controls.Add(this.buttonDone);
      this.Controls.Add(this.buttonRefreshComPorts);
      this.Controls.Add(this.labelDataBitsLabel);
      this.Controls.Add(this.labelStopBitsLabel);
      this.Controls.Add(this.labelParityLabel);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.comboBoxBaudRate);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.comboBoxSerialPorts);
      this.Name = "SerialCommunicationUserControl";
      this.Size = new System.Drawing.Size(489, 73);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonRefreshComPorts;
    private System.Windows.Forms.Label labelDataBitsLabel;
    private System.Windows.Forms.Label labelStopBitsLabel;
    private System.Windows.Forms.Label labelParityLabel;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox comboBoxBaudRate;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBoxSerialPorts;
    private System.Windows.Forms.Button buttonDone;
    private System.Windows.Forms.Label labelParity;
    private System.Windows.Forms.Label labelStopBits;
    private System.Windows.Forms.Label labelDataBits;

  }
}
