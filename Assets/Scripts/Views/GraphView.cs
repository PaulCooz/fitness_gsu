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
            var valueTexts = new TextMeshProUGUI[values.Count];
            var dateTexts = new TextMeshProUGUI[values.Count];
            var maxValue = float.MinValue;

            for (var i = 0; i < values.Count; i++)
            {
                valueTexts[i] = Instantiate(textPrefab, leftAxis);
                dateTexts[i] = Instantiate(textPrefab, bottomAxis);

                valueTexts[i].text = values[i].Value.ToString(CultureInfo.CurrentCulture);
                dateTexts[i].text = values[i].DateTime.ToString(CultureInfo.CurrentCulture);

                maxValue = Math.Max(maxValue, values[i].Value);
            }

            yield return new WaitForSeconds(0.5f);

            var positions = new Vector3[values.Count];
            for (var i = 0; i < values.Count; i++)
            {
                positions[i] = new Vector3(valueTexts[i].transform.position.y, values[i].Value / maxValue, 0);
            }

            lineRenderer.positionCount = positions.Length;
            lineRenderer.SetPositions(positions);
        }
    }
}
