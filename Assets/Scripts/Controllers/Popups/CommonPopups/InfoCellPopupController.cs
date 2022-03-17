using Models;
using UnityEngine;
using Views;

namespace Controllers.Popups.CommonPopups
{
    public class InfoCellPopupController : BasePopupController
    {
        [SerializeField]
        private GraphView graphView;

        public void Init(Parameter parameter)
        {
            StartCoroutine(graphView.Show(parameter.Values));
        }
    }
}
