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
      this.label2 = new System.Windows.Forms.Label();
      this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBoxSerialPorts = new System.Windows.Forms.ComboBox();
      this.labelStaticSettings = new System.Windows.Forms.Label();
      this.SuspendLayout();
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
      this.comboBoxBaudRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaudRate_SelectedIndexChanged);
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
      this.comboBoxSerialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxSerialPorts.FormattingEnabled = true;
      this.comboBoxSerialPorts.Location = new System.Drawing.Point(6, 16);
      this.comboBoxSerialPorts.Name = "comboBoxSerialPorts";
      this.comboBoxSerialPorts.Size = new System.Drawing.Size(121, 21);
      this.comboBoxSerialPorts.TabIndex = 15;
      this.comboBoxSerialPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerialPorts_SelectedIndexChanged);
      // 
      // labelStaticSettings
      // 
      this.labelStaticSettings.AutoSize = true;
      this.labelStaticSettings.Enabled = false;
      this.labelStaticSettings.ForeColor = System.Drawing.SystemColors.InactiveCaption;
      this.labelStaticSettings.Location = new System.Drawing.Point(6, 44);
      this.labelStaticSettings.Name = "labelStaticSettings";
      this.labelStaticSettings.Size = new System.Drawing.Size(178, 13);
      this.labelStaticSettings.TabIndex = 30;
      this.labelStaticSettings.Text = "Parity: odd, Stop Bits: 1, Data Bits: 7";
      // 
      // SerialCommunicationUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.labelStaticSettings);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.comboBoxBaudRate);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.comboBoxSerialPorts);
      this.Name = "SerialCommunicationUserControl";
      this.Size = new System.Drawing.Size(285, 67);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label2;
    internal System.Windows.Forms.ComboBox comboBoxBaudRate;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBoxSerialPorts;
    private System.Windows.Forms.Label labelStaticSettings;

  }
}
