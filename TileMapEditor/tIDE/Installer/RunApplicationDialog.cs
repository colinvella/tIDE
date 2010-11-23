using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace tIDE.Installer
{
    public partial class RunApplicationDialog : Form
    {
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public RunApplicationDialog()
        {
            InitializeComponent();
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            SetForegroundWindow(this.Handle);
        }

        private void OnDialogDeactivate(object sender, EventArgs eventArgs)
        {
            SetForegroundWindow(this.Handle);
        }
    }
}
