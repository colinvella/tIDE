using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TileMapEditor.Controls
{
    public partial class CustomMessageBox : Component
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        public CustomMessageBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public DialogResult Show(IWin32Window owner)
        {
            return MessageBox.Show(owner, m_text, m_caption,
                m_messageBoxButtons, m_messageBoxIcon, m_messageBoxDefaultButton, m_messageBoxOptions,
                m_helpFilePath, m_helpNavigator);
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Description("Message box caption displayed in the window title")]
        [Localizable(true)]
        public string Caption
        {
            get { return m_caption; }
            set { m_caption = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Description("Text to display within the message box")]
        [Localizable(true)]
        public string Text
        {
            get { return m_text; }
            set { m_text = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(System.Windows.Forms.MessageBoxButtons.OK)]
        [Description("Buttons to present to the user")]
        public MessageBoxButtons MessageBoxButtons
        {
            get { return m_messageBoxButtons; }
            set { m_messageBoxButtons = value; }
        }

        [Browsable(true)]
        [Category("Behaviour")]
        [DefaultValue(System.Windows.Forms.MessageBoxDefaultButton.Button1)]
        [Description("Button selected by default")]
        public MessageBoxDefaultButton MessageBoxDefaultButton
        {
            get { return m_messageBoxDefaultButton; }
            set { m_messageBoxDefaultButton = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(System.Windows.Forms.MessageBoxIcon.None)]
        [Description("Icon displayed within the message box")]
        public MessageBoxIcon MessageBoxIcon
        {
            get { return m_messageBoxIcon; }
            set { m_messageBoxIcon = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly)]
        [Description("Presentation options for the message box")]
        [Localizable(true)]
        public MessageBoxOptions MessageBoxOptions
        {
            get { return m_messageBoxOptions; }
            set { m_messageBoxOptions = value; }
        }

        [Browsable(true)]
        [Category("Misc")]
        [DefaultValue(null)]
        [Description("Optional path to the associated helpfile")]
        [Localizable(true)]
        public string HelpFilePath
        {
            get { return m_helpFilePath; }
            set { m_helpFilePath = value; }
        }

        [Browsable(true)]
        [Category("Misc")]
        [DefaultValue(null)]
        [Description("Optional help navigator reference")]
        public HelpNavigator HelpNavigator
        {
            get { return m_helpNavigator; }
            set { m_helpNavigator = value; }
        }

        private string m_caption;
        private string m_text;
        private MessageBoxButtons m_messageBoxButtons;
        private MessageBoxDefaultButton m_messageBoxDefaultButton;
        private MessageBoxIcon m_messageBoxIcon;
        private MessageBoxOptions m_messageBoxOptions;
        private string m_helpFilePath;
        private HelpNavigator m_helpNavigator;
    }
}
