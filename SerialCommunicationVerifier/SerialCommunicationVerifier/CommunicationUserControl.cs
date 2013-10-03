using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialCommunicationVerifier
{
  public partial class CommunicationUserControl : UserControl
  {
    protected Action<Font, string> writeToListBox;
    protected Action onConnected;
    protected Action onDisconnected;

    public CommunicationUserControl()
    {
      this.InitializeComponent(); 
    }

    public CommunicationUserControl(Action<Font, string> writeToListBox, Action onConnected, Action onDisconnected)
    {
      this.InitializeComponent(); 

      this.writeToListBox = writeToListBox;
      this.onConnected = onConnected;
      this.onDisconnected = onDisconnected;
    }

    public virtual void Write(string message) { }
    public virtual void Close() { }
  }
}
