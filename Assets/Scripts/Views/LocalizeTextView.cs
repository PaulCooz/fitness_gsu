using Controllers;
using Models;
using TMPro;
using UnityEngine;

namespace Views
{
    public class LocalizeTextView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textMesh;

        [SerializeField]
        private LocalizeManager.LocalizeKey key;

        private void OnEnable()
        {
            SetText();
            LocalizeController.OnLanguageChange += SetText;
        }

        private void OnDisable()
        {
            LocalizeController.OnLanguageChange -= SetText;
        }

        private void SetText()
        {
            textMesh.text = LocalizeController.Get(key);
        }
    }
}
