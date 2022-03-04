using System.Globalization;
using Controllers.Popups;
using Controllers.Popups.CommonPopups;
using Models;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class DataCellController : MonoBehaviour
    {
        private Parameter _parameter;
        private PopupsController _popupsController;

        [SerializeField]
        private InfoCellPopupController infoCellPopup;
        [SerializeField]
        private TextMeshProUGUI cellName;
        [SerializeField]
        private TextMeshProUGUI cellValue;

        public void Init(Parameter parameter, PopupsController popupsController)
        {
            _parameter = parameter;
            _popupsController = popupsController;

            UpdateText();
        }

        public void OnClick()
        {
            var infoPopup = _popupsController.Push(infoCellPopup);
            infoPopup.Init(_parameter);
        }

        private void UpdateText()
        {
            cellName.text = _parameter.Key;
            cellValue.text = _parameter.GetLast().Value.ToString(CultureInfo.CurrentCulture);
        }
    }
}
