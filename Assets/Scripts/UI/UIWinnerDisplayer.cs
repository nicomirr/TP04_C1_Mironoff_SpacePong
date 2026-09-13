using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Game.Core;
using Game.Events;

namespace Game.UI
{
    public class UIWinnerDisplayer : MonoBehaviour
    {        
        [SerializeField] private List<WinnersTextSo> _winnersText = new List<WinnersTextSo>();
        private Dictionary<PlayerType, string> _winnersTextDictionary;

        private CanvasGroup _canvasGroup;
        private TMP_Text _winnerText;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _winnerText = GetComponentInChildren<TMP_Text>();

            _winnersTextDictionary = new Dictionary<PlayerType, string>();

            foreach (WinnersTextSo winnerText in _winnersText)
            {
                _winnersTextDictionary.Add(winnerText.PlayerType, winnerText.PlayerText);
            }
        }

        private void Start()
        {
            _canvasGroup.alpha = 0f;
        }

        private void OnEnable()
        {
            MatchEvents.OnRoundStarted += HideWinnerText;
            MatchEvents.OnPointScored += DisplayRoundWinner;
            MatchEvents.OnMatchFinished += DisplayMatchWinner;
        }

        private void OnDisable()
        {
            MatchEvents.OnRoundStarted -= HideWinnerText;
            MatchEvents.OnPointScored -= DisplayRoundWinner;
            MatchEvents.OnMatchFinished -= DisplayMatchWinner;
        }

        private void HideWinnerText(int _)
        {
            _canvasGroup.alpha = 0f;
        }

        private void DisplayRoundWinner(PlayerType player)
        {
            string winner = _winnersTextDictionary[player];

            _winnerText.text = "Point to " + winner;
            _canvasGroup.alpha = 1f;
        }

        private void DisplayMatchWinner(PlayerType player)
        {
            string winner = _winnersTextDictionary[player];

            _winnerText.text = winner + " wins";
            _canvasGroup.alpha = 1f;
        }               

    }
}

