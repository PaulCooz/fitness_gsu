using DG.Tweening;
using UnityEngine;

namespace Controllers
{
    public class SettingController : MonoBehaviour
    {
        private void Awake()
        {
            DOTween.Init(true, false, LogBehaviour.Verbose);
        }
    }
}
