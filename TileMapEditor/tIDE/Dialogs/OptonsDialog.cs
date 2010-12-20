using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using tIDE.Localisation;
using System.IO;

namespace tIDE.Dialogs
{
    public partial class OptonsDialog : Form
    {
        public OptonsDialog()
        {
            InitializeComponent();
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            // history
            m_recentFileCountUpDown.Value = RecentFilesManager.MaxFilenameCount;
            m_clearHistory = false;
            m_clearHistoryButton.Enabled = RecentFilesManager.Filenames.Count > 0;

            // language
            foreach (Language language in Language.List)
                m_languageComboBox.Items.Add(language.Name);

            Language currentLanguage = LanguageManager.Language;
            for (int index = 0; index < Language.List.Count; index++)
            {
                if (currentLanguage == Language.List[index])
                {
                    m_languageComboBox.SelectedIndex = index;
                    break;
                }
            }

            // editing tool
            string editingToolPath = Properties.Settings.Default.ImageEditingTool.Trim();
            m_rdbDefaultAssociation.Checked = editingToolPath.Length == 0;
            m_rdbSpecificTool.Checked = !m_rdbDefaultAssociation.Checked;
            m_txtEditingToolPath.Enabled = m_rdbSpecificTool.Checked;
            m_txtEditingToolPath.Text = editingToolPath;
        }

        private void OnClearHistory(object sender, EventArgs eventArgs)
        {
            m_clearHistoryButton.Enabled = false;
            m_clearHistory = true;
        }

        private void OnCheckedChanged(object sender, EventArgs eventArgs)
        {
            if (sender == m_rdbDefaultAssociation)
            {
                m_rdbSpecificTool.Checked = !m_rdbDefaultAssociation.Checked;
            }
            else if (sender == m_rdbSpecificTool)
            {
                m_rdbDefaultAssociation.Checked = !m_rdbSpecificTool.Checked;
            }


            m_txtEditingToolPath.Enabled = m_rdbSpecificTool.Checked;
            m_btnBrowseEditingTool.Enabled = m_rdbSpecificTool.Checked;
        }

        private void OnBrowseEditingTool(object sender, EventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = "Executable Files (*.exe)|*.exe";

            if (m_txtEditingToolPath.Text.Length == 0)
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            else
                openFileDialog.InitialDirectory = Path.GetDirectoryName(m_txtEditingToolPath.Text);


            openFileDialog.Multiselect = false;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            m_txtEditingToolPath.Text = openFileDialog.FileName;
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            if (m_clearHistory)
                RecentFilesManager.ClearHistory();

            LanguageManager.Language
                = Language.FromName(m_languageComboBox.SelectedItem.ToString());

            if (m_rdbSpecificTool.Checked)
                Properties.Settings.Default.ImageEditingTool = m_txtEditingToolPath.Text;
            else
                Properties.Settings.Default.ImageEditingTool = "";
            Properties.Settings.Default.Save();
        }

        private bool m_clearHistory;
    }
}
