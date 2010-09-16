using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;

namespace TileMapEditor.Plugin
{
    public class ApplicationRegistry
    {
        public class MenuStrip
        {
            public class FileMenu
            {
                public static string Name
                {
                    get
                    {
                        switch (CurrentLanguage)
                        {
                            case Language.English: return "&File";
                            case Language.Italian: return "&Fascicolo";
                            default: throw new Exception();
                        }
                    }
                }
            }

            public class EditMenu
            {
                public static string Name
                {
                    get
                    {
                        switch (CurrentLanguage)
                        {
                            case Language.English: return "&Edit";
                            case Language.Italian: return "&Modifica";
                            default: throw new Exception();
                        }
                    }
                }
            }

            public class ViewMenu
            {
                public static string Name
                {
                    get
                    {
                        switch (CurrentLanguage)
                        {
                            case Language.English: return "&View";
                            case Language.Italian: return "&Visualizza";
                            default: throw new Exception();
                        }
                    }
                }
            }

            public class MapMenu
            {
                public static string Name
                {
                    get
                    {
                        switch (CurrentLanguage)
                        {
                            case Language.English: return "&Map";
                            case Language.Italian: return "Ma&ppa";
                            default: throw new Exception();
                        }
                    }
                }
            }

            public class LayerMenu
            {
                public static string Name
                {
                    get
                    {
                        switch (CurrentLanguage)
                        {
                            case Language.English: return "&Layer";
                            case Language.Italian: return "&Strato";
                            default: throw new Exception();
                        }
                    }
                }
            }

            public class TileSheetMenu
            {
                public static string Name
                {
                    get
                    {
                        switch (CurrentLanguage)
                        {
                            case Language.English: return "&Tile Sheet";
                            case Language.Italian: return "Foglio di &Piastre";
                            default: throw new Exception();
                        }
                    }
                }
            }

            public class PluginMenu
            {
                public static string Name
                {
                    get
                    {
                        switch (CurrentLanguage)
                        {
                            case Language.English: return "&Plugin";
                            case Language.Italian: return "Mo&dulo";
                            default: throw new Exception();
                        }
                    }
                }
            }

            public class HelpMenu
            {
                public static string Name
                {
                    get
                    {
                        switch (CurrentLanguage)
                        {
                            case Language.English: return "&Help";
                            case Language.Italian: return "&Aiuto";
                            default: throw new Exception();
                        }
                    }
                }
            }
        }

        private enum Language
        {
            English,
            Italian
        }

        private static Language CurrentLanguage
        {
            get
            {
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentUICulture;
                string code = cultureInfo.Name;
                if (code == "en-GB")
                    return Language.English;
                else if (code == "it-IT")
                    return Language.Italian;
                else
                    return Language.English;
            }
        }
    }
}
