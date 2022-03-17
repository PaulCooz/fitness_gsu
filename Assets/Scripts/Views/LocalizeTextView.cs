using Models.Localizations;
using TMPro;
using UnityEngine;

namespace Views
{
    public class LocalizeTextView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textMesh;

        [SerializeField]
        private LocalizeKey key;

        private void Start()
        {
            SetText();
            LocalizeManager.OnLanguageChange += SetText;
        }

        private void SetText()
        {
            textMesh.text = LocalizeManager.Get(key);
        }

        private void OnDestroy()
        {
            LocalizeManager.OnLanguageChange -= SetText;
        }
    }
}
