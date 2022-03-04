using System;
using System.Collections.Generic;
using System.Linq;
using Models.Keys;
using Newtonsoft.Json;
using UnityEngine;

namespace Models
{
    public class ParametersManager
    {
        private readonly List<Parameter> _parameters;

        public ParametersManager()
        {
            _parameters = GetAllData();
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
            PlayerPrefs.SetString(PlayerPrefsKeys.DataArray, JsonConvert.SerializeObject(_parameters));
        }

        private List<Parameter> GetAllData()
        {
            return JsonConvert.DeserializeObject<List<Parameter>>
            (
                PlayerPrefs.GetString(PlayerPrefsKeys.DataArray, string.Empty)
            ) ?? new List<Parameter>();
        }
    }
}
