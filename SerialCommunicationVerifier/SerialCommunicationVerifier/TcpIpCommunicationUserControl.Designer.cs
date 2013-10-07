namespace SerialCommunicationVerifier
{
  partial class TcpIpCommunicationUserControl
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
      this.textBoxInstrumentAddress = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.labelPort = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // textBoxInstrumentAddress
      // 
      this.textBoxInstrumentAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxInstrumentAddress.Location = new System.Drawing.Point(7, 20);
      this.textBoxInstrumentAddress.Name = "textBoxInstrumentAddress";
      this.textBoxInstrumentAddress.Size = new System.Drawing.Size(479, 20);
      this.textBoxInstrumentAddress.TabIndex = 0;
      this.textBoxInstrumentAddress.TextChanged += new System.EventHandler(this.textBoxInstrumentAddress_TextChanged);
      this.textBoxInstrumentAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxInstrumentAddress_KeyUp);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(4, 4);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(97, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Instrument Address";
      // 
      // labelPort
      // 
      this.labelPort.AutoSize = true;
      this.labelPort.Location = new System.Drawing.Point(4, 43);
      this.labelPort.Name = "labelPort";
      this.labelPort.Size = new System.Drawing.Size(56, 13);
      this.labelPort.TabIndex = 3;
      this.labelPort.Text = "Port: 7777";
      // 
      // TcpIpCommunicationUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.labelPort);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBoxInstrumentAddress);
      this.Name = "TcpIpCommunicationUserControl";
      this.Size = new System.Drawing.Size(489, 71);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    internal System.Windows.Forms.TextBox textBoxInstrumentAddress;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label labelPort;
  }
}
