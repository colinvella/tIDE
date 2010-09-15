using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using System.Collections.ObjectModel;

namespace TileMapEditor.Localisation
{
    class Language
    {
        public readonly static Language English = new Language(
            "English", CultureInfo.CurrentCulture.Name);
        public readonly static Language Italian = new Language("Italiano", "it-IT");

        public static Language FromCode(string code)
        {
            foreach (Language language in s_list)
                if (language.Code == code)
                    return language;

            return English;
        }

        public static Language FromName(string name)
        {
            foreach (Language language in s_list)
                if (language.Name == name)
                    return language;

            return English;
        }

        public static ReadOnlyCollection<Language> List
        {
            get { return s_list.AsReadOnly(); }
        }

        public override string ToString()
        {
            return m_name + " (" + m_code + ")";
        }

        public string Name
        {
            get { return m_name; }
        }

        public string Code
        {
            get { return m_code; }
        }

        static Language()
        {
            s_list = new List<Language>();
            s_list.Add(English);
            s_list.Add(Italian);
        }

        private Language(string name, string code)
        {
            m_name = name;
            m_code = code;
        }

        private static List<Language> s_list;

        private string m_name;
        private string m_code;
    }
}
