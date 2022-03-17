using System;
using System.Collections.Generic;

namespace Models
{
    public class Parameter
    {
        public readonly struct ValueAndDate
        {
            public readonly float Value;
            public readonly DateTime DateTime;

            public ValueAndDate(float value, DateTime dateTime)
            {
                Value = value;
                DateTime = dateTime;
            }
        }

        public readonly List<ValueAndDate> Values;
        public readonly string Key;
        public readonly bool IsProperty;

        public Parameter(string key, float value, DateTime dateTime, bool isProperty)
        {
            Values = new List<ValueAndDate> {new(value, dateTime)};
            Key = key;

            IsProperty = isProperty;
        }

        public void Add(float value, DateTime dateTime)
        {
            Values.Add(new ValueAndDate(value, dateTime));
        }

        public ValueAndDate GetLast()
        {
            return Values.Back();
        }
    }
}
