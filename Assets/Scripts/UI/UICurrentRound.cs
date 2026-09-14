using UnityEngine;
using Game.Events;
using TMPro;

namespace Game.UI
{
    public class UICurrentRound : MonoBehaviour
    {
        private TMP_Text _roundsText;

        private void Awake()
        {
            _roundsText = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            MatchEvents.OnRoundStarted += UpdateRoundText;
        }

        private void OnDisable()
        {
            MatchEvents.OnRoundStarted -= UpdateRoundText;
        }

        private void UpdateRoundText(int currentRound)
        {
            _roundsText.text = "ROUND " + currentRound.ToString();
        }

    }
}

