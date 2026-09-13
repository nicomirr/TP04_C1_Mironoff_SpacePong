using UnityEngine;
using Game.Data;
using TMPro;

namespace Game.Match
{
    public class MatchTimer
    {
        private readonly int _roundTime;
        private readonly TMP_Text _timerText;

        private float _roundTimer;

        private int _lastDisplayedSecond = -1;

        private bool _isRunning;

        public MatchTimer(MatchConfigSo data, TMP_Text timerText)
        {
            _roundTime = data.RoundTime;
            _timerText = timerText;

            UpdateTimerText(0);
        }

        public void StartTimer()
        {
            _isRunning = true;
        }

        public void UpdateTimer()
        {
            if (!_isRunning) return;

            _roundTimer += Time.deltaTime;

            int elapsedTime = (int)_roundTimer;

            if (elapsedTime == _lastDisplayedSecond)
                return;

            UpdateTimerText(elapsedTime);
        }

        private void UpdateTimerText(int elapsedTime)
        {
            _lastDisplayedSecond = elapsedTime;

            int minutes = elapsedTime / 60;
            int seconds = elapsedTime % 60;

            _timerText.SetText("{0:00}:{1:00}", minutes, seconds);
        }

        public void ResetTimer()
        {
            _roundTimer = 0;
            UpdateTimerText(0);
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