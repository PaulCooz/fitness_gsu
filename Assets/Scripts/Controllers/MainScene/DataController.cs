using System;
using System.Collections.Generic;
using Controllers.Popups;
using Controllers.Popups.CommonPopups;
using Models;
using UnityEngine;

namespace Controllers.MainScene
{
    public class DataController : MonoBehaviour
    {
        private ParametersManager _parametersManager;
        private List<DataCellController> _cellControllers;

        [SerializeField]
        private DataCellController dataCellPrefab;
        [SerializeField]
        private RectTransform cellParentTransform;
        [SerializeField]
        private PopupsController popupsController;
        [SerializeField]
        private AddFieldPopupController addFieldPopupController;

        private void Start()
        {
            _parametersManager = new ParametersManager();
            _cellControllers = new List<DataCellController>();

            CreateNewCells();
        }

        private void UpdateCells()
        {
            ClearCells();
            CreateNewCells();
        }

        private void ClearCells()
        {
            foreach (var cellController in _cellControllers)
            {
                Destroy(cellController.gameObject);
            }

            _cellControllers.Clear();
        }

        private void CreateNewCells()
        {
            foreach (var parameter in _parametersManager.GetParameters())
            {
                var cell = Instantiate(dataCellPrefab, cellParentTransform);
                cell.Init(parameter, popupsController);

                _cellControllers.Add(cell);
            }
        }

        public void ShowAddFieldPopup()
        {
            var popup = popupsController.Push(addFieldPopupController);
            popup.Init(AddValue, _parametersManager.GetKeys(), _parametersManager.GetValues());
        }

        private void AddValue(string key, float value, DateTime dateTime, bool isProperty)
        {
            _parametersManager.AddValue(key, value, dateTime, isProperty);
            _parametersManager.SaveAllData();
            UpdateCells();
        }
    }
}
