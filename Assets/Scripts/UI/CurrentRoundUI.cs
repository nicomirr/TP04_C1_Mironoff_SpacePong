using Game.Events;
using TMPro;
using UnityEngine;

public class CurrentRoundUI : MonoBehaviour
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
