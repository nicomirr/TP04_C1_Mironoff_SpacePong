using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Game.Core;
using Game.Events;

public class WinnerUI : MonoBehaviour
{
    [SerializeField] private List<WinnersTextSo> _winnersText = new List<WinnersTextSo>();
    private Dictionary<PlayerType, string> _winnersTextDictionary = new Dictionary<PlayerType, string>();

    private CanvasGroup _canvasGroup;
    private TMP_Text _winnerText;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _winnerText = GetComponentInChildren<TMP_Text>();

        foreach(WinnersTextSo winnerText in _winnersText)
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
        MatchEvents.OnMatchFinished += DisplayWinner;
    }

    private void OnDisable()
    {
        MatchEvents.OnMatchFinished -= DisplayWinner;
    }

    private void DisplayWinner(PlayerType player)
    {        
        string winner = _winnersTextDictionary[player];

        _winnerText.text = winner + " wins"; 
        _canvasGroup.alpha = 1f;
    }
}
