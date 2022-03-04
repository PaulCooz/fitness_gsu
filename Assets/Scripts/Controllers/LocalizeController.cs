using System;
using System.Linq;
using Models;
using UnityEngine;

namespace Controllers
{
    public class LocalizeController : MonoBehaviour
    {
        private static LocalizeManager _localizeManager;

        private static SystemLanguage _currentLanguage;

        [SerializeField]
        private TextAsset translations;
        [SerializeField]
        private SystemLanguage[] availableLanguages;

        public static event Action OnLanguageChange;

        private static SystemLanguage Language
        {
            get => _currentLanguage;
            set
            {
                _currentLanguage = value;
                OnLanguageChange?.Invoke();
            }
        }

        private void Awake()
        {
            Language = availableLanguages.First();
            _localizeManager = new LocalizeManager(translations.text);
        }

        public static string Get(LocalizeManager.LocalizeKey key)
        {
            return _localizeManager.Get(Language, key);
        }
    }
}