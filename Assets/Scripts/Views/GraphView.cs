using System;
using System.Collections;
using System.Globalization;
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

        public IEnumerator Show(float[] leftValues, float[] bottomValues)
        {
            var size = Math.Min(leftValues.Length, bottomValues.Length);
            var leftTexts = new TextMeshProUGUI[size];
            var bottomTexts = new TextMeshProUGUI[size];
            var maxLeftValue = float.MinValue;

            for (var i = 0; i < size; i++)
            {
                leftTexts[i] = Instantiate(textPrefab, leftAxis);
                bottomTexts[i] = Instantiate(textPrefab, bottomAxis);

                leftTexts[i].text = leftValues[i].ToString(CultureInfo.CurrentCulture);
                bottomTexts[i].text = bottomValues[i].ToString(CultureInfo.CurrentCulture);

                maxLeftValue = Math.Max(maxLeftValue, leftValues[i]);
            }

            yield return new WaitForSeconds(0.5f);

            var positions = new Vector3[size];
            for (var i = 0; i < size; i++)
            {
                positions[i] = new Vector3(leftTexts[i].transform.position.y, leftValues[i] / maxLeftValue, 0);
            }

            lineRenderer.positionCount = positions.Length;
            lineRenderer.SetPositions(positions);
        }
    }
}
