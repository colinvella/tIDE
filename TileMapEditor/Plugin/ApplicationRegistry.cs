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
