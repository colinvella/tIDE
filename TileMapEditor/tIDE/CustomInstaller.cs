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

namespace TileMapEditor
{
    [RunInstaller(true)]
    public partial class CustomInstaller : Installer
    {
        public CustomInstaller()
            : base()
        {
            // attach handler to 'Committed' event.
            this.Committed += new InstallEventHandler(OnInstallerCommitted);
        }

        // Committed event handler
        private void OnInstallerCommitted(object sender, InstallEventArgs installEventArgs)
        {
            if (MessageBox.Show(
                "Do you want to run tIDE now?", "tIDE Tile Map Editor",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.No)
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
