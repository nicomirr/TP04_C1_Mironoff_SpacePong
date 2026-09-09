using UnityEngine;

namespace Game.UI
{
    public class UIPanel : MonoBehaviour
    {
        //poner scriptableobject
        [Range(0.2f, 1f)][SerializeField] private float _onDisplayAlpha = 1f;
        private CanvasGroup _canvasGroup;

        protected virtual void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void DisplayPanel()
        {
            _canvasGroup.alpha = _onDisplayAlpha;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
        }

        public void HidePanel()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;

        }
    }

}
