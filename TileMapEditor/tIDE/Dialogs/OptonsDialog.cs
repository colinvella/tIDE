using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Localisation;

namespace TileMapEditor.Dialogs
{
    public partial class OptonsDialog : Form
    {
        public OptonsDialog()
        {
            InitializeComponent();
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_recentFileCountUpDown.Value = RecentFilesManager.MaxFilenameCount;

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
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            LanguageManager.Language
                = Language.FromName(m_languageComboBox.SelectedItem.ToString());
        }
    }
}
