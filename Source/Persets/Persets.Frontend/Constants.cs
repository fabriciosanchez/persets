using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persets.Frontend
{
    public class Constants
    {
        private static Dictionary<string, string> _languages = new Dictionary<string, string>();

        public const string CurrentCulture = "CurrentCulture";
        public const string DefaultLanguage = "en";    
        public static Dictionary<string, string> Languages
        {
            get
            {
                if (_languages.Any())
                {
                    _languages.Add("pt-BR", "Portuguese");
                    _languages.Add("en-us", "English");
                }

                return _languages;
            }
        }

    }
}