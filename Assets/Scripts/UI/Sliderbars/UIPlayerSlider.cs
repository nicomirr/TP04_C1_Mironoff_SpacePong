using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Game.Core;

namespace Game.UI.Slidebars
{
    public abstract class UIPlayerSlider : MonoBehaviour
    {
        //Esto que se decida luego en cada panel de jugador, no en cada slider individual
        [SerializeField] protected PlayerType _playerType;

        [SerializeField] protected TMP_Text _valueText;
        protected Slider _slider;

        protected virtual void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        protected abstract void UpdateValueText();
    }
}


