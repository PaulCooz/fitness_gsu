using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Controllers.Popups
{
    public class PopupsController : MonoBehaviour
    {
        private readonly Stack<IPopup> _popups = new();

        [SerializeField]
        private RectTransform spawnTransform;
        [SerializeField]
        private RectTransform inputBlocker;

        public T Push<T>(T controller) where T : MonoBehaviour, IPopup
        {
            var popup = Instantiate(controller, spawnTransform);

            if (_popups.IsEmpty()) inputBlocker.gameObject.SetActive(true);
            inputBlocker.SetAsLastSibling();
            popup.transform.SetAsLastSibling();

            popup.Initialize(this);
            _popups.Push(popup);

            return popup;
        }

        public T GetTop<T>() where T : class
        {
            return _popups.IsEmpty() ? null : _popups.Peek() as T;
        }

        public void AnnihilateTop()
        {
            if (_popups.IsEmpty()) return;
            _popups.Pop().Annihilate();

            if (_popups.IsEmpty()) inputBlocker.gameObject.SetActive(false);
        }
    }
}
