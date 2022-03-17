using UnityEngine;

namespace Models.Localizations
{
    [CreateAssetMenu(fileName = NAME, menuName = "Create Localization Object")]
    public class LocalizationObject : ScriptableObject
    {
        private const string NAME = "LocalizationObject";

        [SerializeField]
        private TextAsset translations;
        [SerializeField]
        private SystemLanguage[] availableLanguages;

        public static void ReadData(out string translationsJson, out SystemLanguage[] availableLanguages)
        {
            var localizationObject = Resources.Load<LocalizationObject>(NAME);

            translationsJson = localizationObject.translations.text;
            availableLanguages = localizationObject.availableLanguages;
        }
    }
}
