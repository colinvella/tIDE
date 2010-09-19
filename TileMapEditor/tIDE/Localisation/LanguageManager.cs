using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

namespace TileMapEditor.Localisation
{
    class LanguageManager
    {
        public const string GenericOK = "Generic.OK";
        public const string GenericCancel = "Generic.Cancel";
        public const string GenericApply = "Generic.Apply";
        public const string GenericClose = "Generic.Close";

        public static void Initialise()
        {
            CultureInfo cultureInfo = new CultureInfo(Language.Code);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        public static void ApplyLanguage(Form form)
        {
            ComponentResourceManager componentResourceManager
                = new ComponentResourceManager(form.GetType());
            ApplyLanguage(componentResourceManager, form);
        }

        public static string GetText(Type componentType, string name)
        {
            ComponentResourceManager componentResourceManager
                = new ComponentResourceManager(componentType);
            return componentResourceManager.GetString(name);
        }

        public static Language Language
        {
            get
            {
                CultureInfo cultureInfo = Properties.Settings.Default.Language;
                return Language.FromCode(cultureInfo.Name);
            }
            set
            {
                Language language = value == null ? Language.English : value;

                CultureInfo cultureInfo = new CultureInfo(language.Code);

                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;

                Properties.Settings.Default.Language = cultureInfo;
                Properties.Settings.Default.Save();
            }
        }

        // recursively handles control tree and switches to
        // menu / toolbar / tree view node trees when needed
        private static void ApplyLanguage(
            ComponentResourceManager componentResourceManager,
            Control control)
        {
            if (control is UserControl)
            {
                // use its own CRM
                ComponentResourceManager userControlCRM
                    = new ComponentResourceManager(control.GetType());

                userControlCRM.ApplyResources(control, control.Name);
                foreach (Control childControl in control.Controls)
                    ApplyLanguage(userControlCRM, childControl);

                if (control is Controls.MapTreeView)
                {
                    // bit of a hack due to context menus

                    foreach (ContextMenuStrip contextMenuStrip
                        in ((Controls.MapTreeView)control).ContextMenus)
                        ApplyLanguage(componentResourceManager, contextMenuStrip);
                }

                return;
            }

            componentResourceManager.ApplyResources(control, control.Name);
            foreach (Control childControl in control.Controls)
                ApplyLanguage(componentResourceManager, childControl);

            if (control is ToolStrip)
            {
                // handles derivative MenuStrip too
                ToolStrip toolStrip = (ToolStrip)control;
                foreach (ToolStripItem toolStripItem in toolStrip.Items)
                    ApplyLanguage(componentResourceManager, toolStripItem);
            }
            else if (control is TreeView)
            {
                // handle tree view nodes
                TreeView treeView = (TreeView)control;

                treeView.Nodes.Clear();
                treeView.Nodes.AddRange(new TreeNode[] {
                    ((TreeNode)(componentResourceManager.GetObject(treeView.Name + ".Nodes")))});

                foreach (TreeNode treeNode in treeView.Nodes)
                    ApplyLanguage(componentResourceManager, treeNode);
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

        // recursively handles TreeView nodes
        private static void ApplyLanguage(
            ComponentResourceManager componentResourceManager,
            TreeNode treeNode)
        {
            componentResourceManager.ApplyResources(
                treeNode, treeNode.Name);

            foreach (TreeNode childNode in treeNode.Nodes)
                ApplyLanguage(componentResourceManager, childNode);
        }
    }
}
