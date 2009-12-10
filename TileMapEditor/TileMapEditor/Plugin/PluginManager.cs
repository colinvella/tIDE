using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Dialog;
using TileMapEditor.Plugin.Interface;
using TileMapEditor.Plugin.Bridge;

namespace TileMapEditor.Plugin
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
            IMenuItem pluginDropDownMenu = m_applicationBridge.MenuStrip.DropDownMenus["&Plugins"];

            while (pluginDropDownMenu.SubItems.Count<IMenuItem>() > 1)
                pluginDropDownMenu.SubItems.RemoveItem(pluginDropDownMenu.SubItems[1]);

            if (m_plugins.Count > 0)
            {
                foreach (IPlugin plugin in m_plugins.Values)
                {
                    IMenuItem pluginMenuItem
                        = pluginDropDownMenu.SubItems.AddItem(plugin.Name);
                    pluginMenuItem.Image = plugin.SmallIcon;
                    pluginMenuItem.Tag = plugin;
                    pluginMenuItem.EventHandler = ShowPluginInfo;
                }
            }
            else
            {
                IMenuItem messageItem = pluginDropDownMenu.SubItems.AddItem("No plugins loaded");
                messageItem.Enabled = false;
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

                    // update plugins menu
                    UpdatePluginMenu();
                }
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
                    "Failed to load plugins from the path ' " + pluginsPath + "'. Reason: " + innerException.StackTrace,
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
                        "A problem occured while shutting down plugin '" + plugin.Name + "'. Reason: " + exception.StackTrace,
                        "Plugin Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            m_plugins.Clear();
        }

        public PluginManager(MenuStrip menuStrip)
        {
            m_plugins = new Dictionary<string, IPlugin>();
            m_applicationBridge = new ApplicationBridge(menuStrip);
            //PurgePluginDomain();
        }

        public string PluginsPath
        {
            get { return Path.GetDirectoryName(Application.ExecutablePath)
                + Path.DirectorySeparatorChar + "Plugins"; }
        }
    }
}
