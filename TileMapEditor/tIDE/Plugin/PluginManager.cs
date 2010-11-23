using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using tIDE.Controls;
using tIDE.Dialogs;
using tIDE.Plugin.Interface;
using tIDE.Plugin.Bridge;

namespace tIDE.Plugin
{
    public class PluginManager
    {
        private Dictionary<string, IPlugin> m_plugins;
        private ApplicationBridge m_applicationBridge;

        private void ShowPluginInfo(object sender, EventArgs eventArgs)
        {
            IPlugin plugin = (IPlugin)((ToolStripMenuItem)sender).Tag;

            PluginInfoDialog pluginInfoDialog = new PluginInfoDialog(plugin);
            pluginInfoDialog.ShowDialog();
        }

        private void UpdatePluginMenu()
        {
            IMenuItem pluginDropDownMenu
                = m_applicationBridge.MenuStrip.DropDownMenus[ApplicationRegistry.MenuStrip.PluginMenu.Name];

            //while (pluginDropDownMenu.SubItems.Count<IMenuItem>() > 1)
            //    pluginDropDownMenu.SubItems.Remove(pluginDropDownMenu.SubItems[1]);
            IMenuItem noPluginsLoaded = null;
            for (int index = 0; index < pluginDropDownMenu.SubItems.Count<IMenuItem>(); )
            {
                IMenuItem menuItem = pluginDropDownMenu.SubItems[index];
                if (menuItem.Tag != null && menuItem.Tag is IPlugin)
                    pluginDropDownMenu.SubItems.Remove(menuItem);
                else
                {
                    noPluginsLoaded = menuItem;
                    ++index;
                }
            }

            if (m_plugins.Count > 0)
            {
                foreach (IPlugin plugin in m_plugins.Values)
                {
                    IMenuItem pluginMenuItem
                        = pluginDropDownMenu.SubItems.Add(plugin.Name);
                    pluginMenuItem.Image = plugin.SmallIcon;
                    pluginMenuItem.Tag = plugin;
                    pluginMenuItem.EventHandler = ShowPluginInfo;
                }
                noPluginsLoaded.Visible = false;
            }
            else
            {
                noPluginsLoaded.Visible = true;
            }
        }

        private void LoadPluginsFromAssembly(string assemblyPath)
        {
            try
            {
                if (!File.Exists(assemblyPath))
                    throw new Exception("Plugin assembly '" + assemblyPath + "' not found");

                Assembly pluginAssembly = Assembly.LoadFile(assemblyPath);

                Type iPluginType = typeof(IPlugin);
                foreach (Type type in pluginAssembly.GetTypes())
                {
                    if (!iPluginType.IsAssignableFrom(type))
                        continue;

                    object pluginObject = pluginAssembly.CreateInstance(type.FullName);
                    IPlugin plugin = (IPlugin)pluginObject;

                    if (m_plugins.ContainsKey(plugin.Name))
                        throw new Exception("A plugin with the same name ' "
                            + plugin.Name + "' is already loaded");

                    plugin.Initialise(m_applicationBridge);

                    m_plugins[plugin.Name] = plugin;
                }

                // update plugins menu
                UpdatePluginMenu();
            }
            catch (Exception innerException)
            {
                throw new Exception(
                    "Failed to load plugin assembly '" + assemblyPath + "'",
                    innerException);
            }
        }

        public void LoadPlugins()
        {
            LoadPlugins(PluginsPath);
        }

        public void LoadPlugins(string pluginsPath)
        {
            try
            {
                if (!Directory.Exists(pluginsPath))
                    throw new Exception("Plugins path not found");

                string[] directoryFiles = Directory.GetFiles(pluginsPath);

                foreach (string filename in directoryFiles)
                {
                    try
                    {
                        LoadPluginsFromAssembly(filename);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(null,
                            "Failed to load assembly plugin '" + Path.GetFileName(filename)
                            + "'. Reason: " + exception.StackTrace,
                            "Plugin Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception innerException)
            {
                MessageBox.Show(null,
                    "Failed to load plugins from the path ' " + pluginsPath + "'. Reason: " + innerException.Message,
                    "Plugin Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdatePluginMenu();
        }

        public void UnloadPlugins()
        {
            foreach (IPlugin plugin in m_plugins.Values)
            {
                try
                {
                    plugin.Shutdown(m_applicationBridge);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(null,
                        "A problem occured while shutting down plugin '" + plugin.Name + "'. Reason: " + exception.Message + " Stack Trace:" + exception.StackTrace,
                        "Plugin Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            m_plugins.Clear();
        }

        public PluginManager(MenuStrip menuStrip, ToolStripContainer toolStripContainer, MapPanel mapPanel)
        {
            m_plugins = new Dictionary<string, IPlugin>();
            m_applicationBridge = new ApplicationBridge(menuStrip, toolStripContainer, mapPanel);
            //PurgePluginDomain();
        }

        public string PluginsPath
        {
            get { return Path.GetDirectoryName(Application.ExecutablePath)
                + Path.DirectorySeparatorChar + "Plugins"; }
        }
    }
}
