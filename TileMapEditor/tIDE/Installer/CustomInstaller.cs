using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;

namespace tIDE.Installer
{
    [RunInstaller(true)]
    public partial class CustomInstaller : System.Configuration.Install.Installer
    {
        public CustomInstaller()
            : base()
        {
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);

            RunApplicationDialog runApplicationDialog = new RunApplicationDialog();
            if (runApplicationDialog.ShowDialog() == DialogResult.No)
                return;

            try
            {
                string applicationPath = Assembly.GetExecutingAssembly().Location;
                string applicationDirectory = Path.GetDirectoryName(applicationPath);

                Directory.SetCurrentDirectory(applicationDirectory);
                Process.Start(applicationPath);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Unable to run application. Reason:" + exception.Message,
                    "tIDE Tile Map Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
