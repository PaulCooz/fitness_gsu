using System;
using DG.Tweening;
using UnityEngine;

namespace Views.Popups
{
    public class BasePopupView : MonoBehaviour
    {
        [SerializeField]
        private RectTransform rectTransform;

        [SerializeField]
        private float animDuration;

        public void Show()
        {
            rectTransform.DOScale(Vector3.one, animDuration);
        }

        public void Hide(Action onDone)
        {
            var sequence = DOTween.Sequence();

            sequence.Append(rectTransform.DOScale(Vector3.zero, animDuration));
            sequence.AppendCallback(() => onDone?.Invoke());
            sequence.Play();
        }
    }
}
