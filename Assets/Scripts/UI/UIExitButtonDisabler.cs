using UnityEngine;

namespace Game.UI
{
    public class UIExitButtonDisabler : MonoBehaviour
    {
        void Start()
        {
#if UNITY_WEBGL
        this.gameObject.SetActive(false);
#endif
        }
    }
}

