using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

namespace TileMapEditor
{
    class Languages
    {
        public static readonly CultureInfo English = Application.CurrentCulture;
        public static readonly CultureInfo Italian = new CultureInfo("it-IT");

        static Languages()
        {
            s_list = new List<CultureInfo>();
            s_list.Add(English);
            s_list.Add(Italian);
        }

        public static bool IsSupported(CultureInfo cultureInfo)
        {
            foreach (CultureInfo language in s_list)
                if (language.Name == cultureInfo.Name)
                    return true;
            return false;
        }

        private static List<CultureInfo> s_list;
    }

    class LanguageManager
    {
        public static void ApplyLanguage(Form form)
        {
            ComponentResourceManager componentResourceManager
                = new ComponentResourceManager(form.GetType());
            ApplyLanguage(componentResourceManager, form);
        }

        public static CultureInfo Language
        {
            get
            {
                return Properties.Settings.Default.Language;
            }
            set
            {
                CultureInfo language = value;
                if (!Languages.IsSupported(value))
                    language = Languages.English;

                Thread.CurrentThread.CurrentCulture = language;
                Thread.CurrentThread.CurrentUICulture = language;

                Properties.Settings.Default.Language = language;
                Properties.Settings.Default.Save();
            }
        }

        // recursively handles control tree and switches to
        // menu / toolbar tree when needed
        private static void ApplyLanguage(
            ComponentResourceManager componentResourceManager,
            Control control)
        {
            componentResourceManager.ApplyResources(control, control.Name);

            foreach (Control childControl in control.Controls)
                ApplyLanguage(componentResourceManager, childControl);

            // switch to different recursive method for menus / toolbars
            if (control is ToolStrip)
            {
                // handles derivative MenuStrip too
                ToolStrip toolStrip = (ToolStrip)control;
                foreach (ToolStripItem toolStripItem in toolStrip.Items)
                    ApplyLanguage(componentResourceManager, toolStripItem);
            }
        }

        // recursively handles menu / toolbar tree
        private static void ApplyLanguage(
            ComponentResourceManager componentResourceManager,
            ToolStripItem toolStripItem)
        {
            componentResourceManager.ApplyResources(
                toolStripItem, toolStripItem.Name);

            if (toolStripItem is ToolStripMenuItem)
            {
                ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)toolStripItem;

                ToolStripDropDown toolStripDropDown = toolStripMenuItem.DropDown;
                componentResourceManager.ApplyResources(
                    toolStripDropDown, toolStripDropDown.Name);

                foreach (ToolStripItem childToolStripItem in toolStripDropDown.Items)
                    ApplyLanguage(componentResourceManager, childToolStripItem);
            }
        }
    }
}
