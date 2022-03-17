using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using UnityEngine;

namespace Models.LuaModule
{
    public class LuaExpressionManager<T>
    {
        private const string RESULT_KEY = "expressionResult";

        private readonly Script _script;

        public LuaExpressionManager(IReadOnlyList<string> keys, IReadOnlyList<T> values)
        {
            _script = new Script();
            for (var i = 0; i < Math.Min(keys.Count, values.Count); i++)
            {
                _script.Globals[keys[i]] = values[i];
            }
        }

        public bool Calculate(string expression, out double result)
        {
            try
            {
                _script.DoString($"{RESULT_KEY}={expression}");
                result = _script.Globals.Get(RESULT_KEY).Number;
                return true;
            }
            catch (Exception exception)
            {
                Debug.LogWarning(exception);
                result = default;
                return false;
            }
        }
    }
}
