using UnityEngine;
using TMPro;
using Game.Core;
using Game.Data;
using Game.Events;


namespace Game.UI
{
    public class PlayerScoreUI : MonoBehaviour
    {
        [SerializeField] private ScoreUIConfigSo _scoreUIConfigSo;
        private TMP_Text _scoreText;

        private void Awake()
        {
            _scoreText = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            MatchEvents.OnScoreChanged += UpdateScore;
        }

        private void OnDisable()
        {
            MatchEvents.OnScoreChanged -= UpdateScore;
        }

        private void UpdateScore(PlayerType playerType, int score)
        {
            if (playerType != _scoreUIConfigSo.Player) return;

            _scoreText.text = score.ToString();
        }

    }

}
