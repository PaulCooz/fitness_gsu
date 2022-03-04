using System;
using System.Collections.Generic;
using Models.LuaModule;

namespace Controllers.Popups.CommonPopups
{
    public class AddFieldPopupController : BasePopupController
    {
        private LuaExpressionManager<float> _luaExpressionManager;

        private string _keyField;
        private string _valueField;

        private event Action<string, float, DateTime, bool> OnAddValue;

        public void Init(Action<string, float, DateTime, bool> addFloat, List<string> scopeNames, List<float> scopeValues)
        {
            _luaExpressionManager = new LuaExpressionManager<float>(scopeNames, scopeValues);
            OnAddValue = addFloat;
        }

        public void OnChoseKey(string key)
        {
            _keyField = key;
        }

        public void OnChoseValue(string value)
        {
            _valueField = value;
        }

        public void OnDone()
        {
            var isSend = false;
            if (float.TryParse(_valueField, out var result))
            {
                OnAddValue?.Invoke(_keyField.ToLower(), result, DateTime.Now, false);
                isSend = true;
            }
            else if (TryGetProperty(_valueField, out var property))
            {
                OnAddValue?.Invoke(_keyField.ToLower(), property, DateTime.Now, true);
                isSend = true;
            }

            if (isSend) Hide();
        }

        private bool TryGetProperty(string expression, out float property)
        {
            var isCalculate = _luaExpressionManager.Calculate(expression.ToLower(), out var result);
            property = (float) result;

            return isCalculate;
        }
    }
}
