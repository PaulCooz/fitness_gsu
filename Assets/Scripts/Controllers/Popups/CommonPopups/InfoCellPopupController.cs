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
            StartCoroutine(graphView.Show(new[] {100f, 110f, 120f, 130f, 112f, 103f}, new[] {0.6f, 1f, 2f, 3f, 3f, 5f}));
        }
    }
}
