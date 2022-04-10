using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Models;
using TMPro;
using UnityEngine;

namespace Views
{
    public class GraphView : MonoBehaviour
    {
        [SerializeField]
        private LineRenderer lineRenderer;
        [SerializeField]
        private RectTransform leftAxis;
        [SerializeField]
        private RectTransform bottomAxis;
        [SerializeField]
        private TextMeshProUGUI textPrefab;

        public IEnumerator Show(List<Parameter.ValueAndDate> values)
        {
            var uniqValues = GetUniqValues(values);
            var dateTexts = GetDataTexts(values);
            var valueTexts = GetValueTexts(uniqValues);

            var waitForAnimEnd = new WaitForSeconds(0.5f);
            yield return waitForAnimEnd;

            var positions = GetPositions(values, valueTexts, dateTexts);

            lineRenderer.positionCount = positions.Length;
            lineRenderer.SetPositions(positions);
        }

        private static Vector3[] GetPositions(IReadOnlyList<Parameter.ValueAndDate> values,
            IReadOnlyList<TextMeshProUGUI> valueTexts, IReadOnlyList<TextMeshProUGUI> dateTexts)
        {
            var positions = new Vector3[values.Count];
            for (var i = 0; i < values.Count; i++)
            {
                var k = 0;
                for (var j = 0; j < valueTexts.Count; j++)
                {
                    if (valueTexts[j].text != values[i].Value.ToString(CultureInfo.CurrentCulture)) continue;

                    k = j;
                    break;
                }

                positions[i] = new Vector3(dateTexts[i].transform.position.x, valueTexts[k].transform.position.y, 0);
            }

            return positions;
        }

        private TextMeshProUGUI[] GetValueTexts(IReadOnlyList<float> uniqValues)
        {
            var valueTexts = new TextMeshProUGUI[uniqValues.Count];
            for (var i = 0; i < uniqValues.Count; i++)
            {
                valueTexts[i] = Instantiate(textPrefab, leftAxis);
                valueTexts[i].text = uniqValues[i].ToString(CultureInfo.CurrentCulture);
            }

            return valueTexts;
        }

        private TextMeshProUGUI[] GetDataTexts(IReadOnlyList<Parameter.ValueAndDate> values)
        {
            var dateTexts = new TextMeshProUGUI[values.Count];
            for (var i = 0; i < values.Count; i++)
            {
                dateTexts[i] = Instantiate(textPrefab, bottomAxis);
                dateTexts[i].text = values[i].DateTime.ToString(CultureInfo.CurrentCulture);
            }

            return dateTexts;
        }

        private static List<float> GetUniqValues(IReadOnlyList<Parameter.ValueAndDate> values)
        {
            var uniqValues = new List<float>();
            for (var i = 0; i < values.Count; i++)
            {
                if (uniqValues.Contains(values[i].Value)) continue;

                uniqValues.Add(values[i].Value);
            }

            uniqValues.Sort((f1, f2) => f2.CompareTo(f1));
            return uniqValues;
        }
    }
}
