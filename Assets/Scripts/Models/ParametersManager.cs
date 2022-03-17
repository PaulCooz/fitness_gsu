using System;
using System.Collections.Generic;
using System.Linq;
using Models.SaveManages;

namespace Models
{
    public class ParametersManager
    {
        private readonly List<Parameter> _parameters;

        public ParametersManager()
        {
            _parameters = SaveManager.Current.Get(SaveManager.DataArray, new List<Parameter>());
        }

        public void AddValue(string key, float value, DateTime dateTime, bool isProperty)
        {
            if (_parameters.Any(v => v.Key == key))
            {
                foreach (var parameter in _parameters.Where(p => p.Key == key))
                {
                    parameter.Add(value, dateTime);
                }
            }
            else
            {
                _parameters.Add(new Parameter(key, value, dateTime, isProperty));
            }
        }

        public List<Parameter> GetParameters()
        {
            return new List<Parameter>(_parameters);
        }

        public List<string> GetKeys()
        {
            return _parameters.Select(parameter => parameter.Key).ToList();
        }

        public List<float> GetValues()
        {
            return _parameters.Select(parameter => parameter.GetLast().Value).ToList();
        }

        public void SaveAllData()
        {
            SaveManager.Current.Set(SaveManager.DataArray, _parameters);
        }
    }
}
