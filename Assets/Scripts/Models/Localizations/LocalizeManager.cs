using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Models.Localizations
{
    public class LocalizeManager
    {
        private static readonly Dictionary<LocalizeKey, Dictionary<SystemLanguage, string>> Languages;

        private static SystemLanguage _currentLanguage;

        public static event Action OnLanguageChange;

        public static SystemLanguage Language
        {
            get => _currentLanguage;
            set
            {
                _currentLanguage = value;
                OnLanguageChange?.Invoke();
            }
        }

        static LocalizeManager()
        {
            LocalizationObject.ReadData(out var json, out var availableLanguages);

            var defaultLanguage = availableLanguages.Front();
            foreach (var language in availableLanguages)
            {
                if (language != Application.systemLanguage) continue;

                defaultLanguage = language;
                break;
            }

            _currentLanguage = defaultLanguage;
            Languages = JsonConvert.DeserializeObject<Dictionary<LocalizeKey, Dictionary<SystemLanguage, string>>>(json);
        }

        public static string Get(in LocalizeKey key)
        {
            return Languages[key][_currentLanguage];
        }
    }
}
