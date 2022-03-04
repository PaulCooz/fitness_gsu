using UnityEngine;

namespace Views
{
    public class ViewsController : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] content;

        public void SetContent(int x)
        {
            for (var i = 0; i < content.Length; i++)
            {
                content[i].SetActive(i == x);
            }
        }
    }
}
