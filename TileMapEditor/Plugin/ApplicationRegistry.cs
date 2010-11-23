using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;

namespace tIDE.Plugin
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
                            case Language.French: return "&Fichier";
                            case Language.Spanish: return "&Archivo";
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
                            case Language.French: return "&Edition";
                            case Language.Spanish: return "&Edita";
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
                            case Language.French: return "&Affichage";
                            case Language.Spanish: return "&Ver";
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
                            case Language.French: return "&Carte";
                            case Language.Spanish: return "&Mapa";
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
                            case Language.French: return "&Strate";
                            case Language.Spanish: return "&Capa";
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
                            case Language.French: return "&Feuille des Tuiles";
                            case Language.Spanish: return "&Hoja de Azulejos";
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
                            case Language.French: return "&Module";
                            case Language.Spanish: return "Módul&o";
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
                            case Language.French: return "Ai&de";
                            case Language.Spanish: return "A&yuda";
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
            French,
            Spanish,
            Italian
        }

        private static Language CurrentLanguage
        {
            get
            {
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentUICulture;
                string code = cultureInfo.Name;
                if (code.StartsWith("en-"))
                    return Language.English;
                if (code.StartsWith("fr-"))
                    return Language.French;
                if (code.StartsWith("es-"))
                    return Language.Spanish;
                if (code.StartsWith("it-"))
                    return Language.Italian;
                else
                    return Language.English;
            }
        }
    }
}
