using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;

namespace TileMapEditor.Controls
{
    public partial class CustomMessageBox : Component
    {
        public CustomMessageBox()
        {
            m_messageBoxButtons = MessageBoxButtons.OK;
            m_messageBoxDefaultButton = MessageBoxDefaultButton.Button1;
            m_messageIcon = MessageIcon.None;
            m_messageBoxOptions = 0;
            m_helpNavigator = HelpNavigator.Topic;
            m_variableDictionary = new Dictionary<string, object>();

            InitializeComponent();
        }

        public CustomMessageBox(IContainer container)
        {
            m_messageBoxButtons = MessageBoxButtons.OK;
            m_messageBoxDefaultButton = MessageBoxDefaultButton.Button1;
            m_messageIcon = MessageIcon.None;
            m_messageBoxOptions = 0;
            m_helpNavigator = HelpNavigator.Topic;
            m_variableDictionary = new Dictionary<string, object>();

            container.Add(this);

            InitializeComponent();
        }

        public DialogResult Show()
        {
            string caption = EvaluateText(m_caption);
            string text = EvaluateText(m_text);

            MessageBoxIcon messageBoxIcon = MessageBoxIcon.None;
            switch (m_messageIcon)
            {
                case MessageIcon.None: messageBoxIcon = MessageBoxIcon.None; break;
                case MessageIcon.Information: messageBoxIcon = MessageBoxIcon.Information; break;
                case MessageIcon.Warning: messageBoxIcon = MessageBoxIcon.Warning; break;
                case MessageIcon.Error: messageBoxIcon = MessageBoxIcon.Error; break;
                case MessageIcon.Question: messageBoxIcon = MessageBoxIcon.Question; break;
            }

            if (m_helpFilePath == null)
                return MessageBox.Show(m_owner, text, caption,
                    m_messageBoxButtons, messageBoxIcon, m_messageBoxDefaultButton, m_messageBoxOptions);
            else
                return MessageBox.Show(m_owner, text, caption,
                    m_messageBoxButtons, messageBoxIcon, m_messageBoxDefaultButton, m_messageBoxOptions,
                    m_helpFilePath, m_helpNavigator);
            }

        [Browsable(true)]
        [Category("Misc")]
        [DefaultValue(null)]
        [Description("Owner of this message box")]
        public IWin32Window Owner
        {
            get { return m_owner; }
            set { m_owner = value; }
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
        public MessageBoxButtons Buttons
        {
            get { return m_messageBoxButtons; }
            set { m_messageBoxButtons = value; }
        }

        [Browsable(true)]
        [Category("Behaviour")]
        [DefaultValue(System.Windows.Forms.MessageBoxDefaultButton.Button1)]
        [Description("Button selected by default")]
        public MessageBoxDefaultButton DefaultButton
        {
            get { return m_messageBoxDefaultButton; }
            set { m_messageBoxDefaultButton = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(MessageIcon.None)]
        [Description("Icon displayed within the message box")]
        public MessageIcon Icon
        {
            get { return m_messageIcon; }
            set { m_messageIcon = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly)]
        [Description("Presentation options for the message box")]
        [Localizable(true)]
        public MessageBoxOptions Options
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
        [DefaultValue(System.Windows.Forms.HelpNavigator.Topic)]
        [Description("Optional help navigator reference")]
        public HelpNavigator HelpNavigator
        {
            get { return m_helpNavigator; }
            set { m_helpNavigator = value; }
        }

        public IDictionary<string, object> VariableDictionary
        {
            get { return m_variableDictionary; }
        }

        private string ResolveReference(string reference)
        {
            if (m_variableDictionary.ContainsKey(reference))
                return m_variableDictionary[reference].ToString();

            if (m_owner == null)
                return "(ERROR: Owner property not set)";

            string[] tokens = reference.Split(new char[] { '.' });
            object obj = m_owner;
            foreach (string token in tokens)
            {
                Type type = obj.GetType();

                FieldInfo fieldInfo = type.GetField(token, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                PropertyInfo propertyInfo = fieldInfo != null
                    ? null
                    : type.GetProperty(token, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (fieldInfo != null)
                    obj = fieldInfo.GetValue(obj);
                else if (propertyInfo != null)
                    obj = propertyInfo.GetValue(obj, null);
                else
                    return "(ERROR: unkownn field or property '" + token + "')";
            }

            if (obj == null)
                return "(null)";
            else
                return obj.ToString();
        }

        private string EvaluateText(string input)
        {
            int position = input.IndexOf('[');
            if (position < 0)
                return input;

            StringBuilder output = new StringBuilder();
            Match match = s_regex.Match(input);
            int literalIndex = 0;
            foreach (Capture capture in match.Captures)
            {
                if (literalIndex != capture.Index)
                {
                    string literalSegment
                        = input.Substring(literalIndex, capture.Index - literalIndex);
                    output.Append(literalSegment);
                }
                string reference = capture.Value.Replace("[", "").Replace("]", "");
                string value = ResolveReference(reference);
                output.Append(value);
                literalIndex = capture.Index + capture.Length;
            }
            if (literalIndex < input.Length)
                output.Append(input.Substring(literalIndex));
            
            return output.ToString();
        }

        private static Regex s_regex = new Regex(@"\[.*\]", RegexOptions.Compiled);

        private IWin32Window m_owner;
        private string m_caption;
        private string m_text;
        private MessageBoxButtons m_messageBoxButtons;
        private MessageBoxDefaultButton m_messageBoxDefaultButton;
        private MessageIcon m_messageIcon;
        private MessageBoxOptions m_messageBoxOptions;
        private string m_helpFilePath;
        private HelpNavigator m_helpNavigator;
        private Dictionary<string, object> m_variableDictionary;
    }

    public enum MessageIcon
    {
        None,
        Information,
        Warning,
        Error,
        Question
    }
}
