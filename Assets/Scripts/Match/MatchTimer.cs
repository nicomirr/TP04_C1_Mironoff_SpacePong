using UnityEngine;
using Game.Data;
using TMPro;

namespace Game.Match
{
    public class MatchTimer
    {
        private bool _isRunning;

        private int _roundTime;
        private TMP_Text _timerText;

        private float _roundTimer;

        public MatchTimer(MatchConfigSo data, TMP_Text timerText)
        {
            _roundTime = data.RoundTime;
            _timerText = timerText;
        }

        public void StartTimer()
        {
            _isRunning = true;
        }

        public void UpdateTimer()
        {
            if (!_isRunning) return;

            _roundTimer += Time.deltaTime;

            UpdateTimerText();
        }

        private void UpdateTimerText()
        {
            int minutes = 0;
            int seconds = 0;
            int elapsedTime = (int)_roundTimer;

            while (elapsedTime >= 60)
            {
                elapsedTime -= 60;
                minutes++;
            }

            seconds = elapsedTime;

            _timerText.text = minutes.ToString("D2") + ":" +
                seconds.ToString("D2");
        }

        public void ResetTimer()
        {
            _roundTimer = 0;
            UpdateTimerText();
        }

        public void StopTimer()
        {
            _isRunning = false;
        }

        public bool CheckTimeLimitReached()
        {
            return _roundTimer >= _roundTime;
        }
    }
}

