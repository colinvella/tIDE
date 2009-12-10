using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Plugin.Bridge;

namespace TileMapEditor.Plugin
{
    public class PluginManager
    {
        private AppDomain m_pluginDomain;
        private Dictionary<string, IPlugin> m_plugins;
        private ApplicationBridge m_applicationBridge;

        private void PurgePluginDomain()
        {
            if (m_pluginDomain != null)
                AppDomain.Unload(m_pluginDomain);
            m_pluginDomain = AppDomain.CreateDomain("TileMapEditorPluginDomain");
        }

        private void LoadPluginsFromAssembly(string assemblyPath)
        {
            try
            {
                if (!File.Exists(assemblyPath))
                    throw new Exception("Plugin assembly '" + assemblyPath + "' not found");

                byte[] assemblyByteCode = File.ReadAllBytes(assemblyPath);

                Assembly pluginAssembly = m_pluginDomain.Load(assemblyByteCode);

                Type iPluginType = typeof(IPlugin);
                //Type[] constructorSignature = new Type[0];
                //object[] constructorParameters = new object[0];
                foreach (Type type in pluginAssembly.GetTypes())
                {
                    if (!iPluginType.IsAssignableFrom(type))
                        continue;

                    /*
                    ConstructorInfo pluginConstructor
                        = iPluginType.GetConstructor(constructorSignature);

                    if (pluginConstructor == null)
                        throw new Exception(
                            "The plugin class '" + iPluginType.FullName
                            + "' does not define a default constructor");

                    object pluginObject = pluginConstructor.Invoke(constructorParameters);
                    IPlugin plugin = (IPlugin)pluginObject;*/

                    object pluginObject = pluginAssembly.CreateInstance(type.FullName);
                    IPlugin plugin = (IPlugin)pluginObject;

                    if (m_plugins.ContainsKey(plugin.Name))
                        throw new Exception("A plugin with the same name ' "
                            + plugin.Name + "' is already loaded");

                    plugin.Initialise(m_applicationBridge);

                    m_plugins[plugin.Name] = plugin;
                }
            }
            catch (Exception innerException)
            {
                throw new Exception(
                    "Failed to load plugin assembly '" + assemblyPath + "'",
                    innerException);
            }
        }

        public void LoadPlugins(string pluginsPath)
        {
            try
            {
                if (!File.Exists(pluginsPath))
                    throw new Exception("Plugins path not found");
                if ((File.GetAttributes(pluginsPath) & FileAttributes.Directory) == 0)
                    throw new Exception("Plugins path is not a directory");

                string[] directoryFiles = Directory.GetFiles(pluginsPath);

                foreach (string filename in directoryFiles)
                {
                    LoadPluginsFromAssembly(filename);
                }
            }
            catch (Exception innerException)
            {
                throw new Exception(
                    "Failed to load plugins from the path ' " + pluginsPath + "'", innerException);
            }
        }

        public void UnloadPlugins()
        {
            foreach (IPlugin plugin in m_plugins.Values)
                plugin.Shutdown(m_applicationBridge);

            m_plugins.Clear();

            PurgePluginDomain();
        }

        public PluginManager(MenuStrip menuStrip)
        {
            m_plugins = new Dictionary<string, IPlugin>();
            m_applicationBridge = new ApplicationBridge(menuStrip);
            PurgePluginDomain();
        }
    }
}
