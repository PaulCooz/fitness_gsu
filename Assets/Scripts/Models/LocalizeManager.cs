using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Models
{
    public class LocalizeManager
    {
        public enum LocalizeKey
        {
            Error,
            ButtonAddField
        }

        private readonly Dictionary<LocalizeKey, Dictionary<SystemLanguage, string>> _languages;

        public LocalizeManager(in string localizeJson)
        {
            _languages = JsonConvert.DeserializeObject<Dictionary<LocalizeKey, Dictionary<SystemLanguage, string>>>(localizeJson);
        }

        public string Get(in SystemLanguage language, in LocalizeKey key)
        {
            return _languages[key][language];
        }
    }
}