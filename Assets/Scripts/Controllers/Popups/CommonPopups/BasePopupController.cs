using UnityEngine;
using Views.Popups;

namespace Controllers.Popups.CommonPopups
{
    public abstract class BasePopupController : MonoBehaviour, IPopup
    {
        private PopupsController _popupsController;

        [SerializeField]
        private BasePopupView basePopupView;

        public void Initialize(PopupsController popupsController)
        {
            _popupsController = popupsController;
            Show();
        }

        private void Show()
        {
            basePopupView.Show();
        }

        public void Hide()
        {
            basePopupView.Hide(() => _popupsController.AnnihilateTop());
        }

        public void Annihilate()
        {
            Destroy(gameObject);
        }
    }
}
