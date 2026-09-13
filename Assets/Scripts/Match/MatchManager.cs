using UnityEngine;
using TMPro;
using System.Collections;
using Game.Core;
using Game.Data;
using Game.Events;

namespace Game.Match
{
    public class MatchManager : MonoBehaviour
    {
        [SerializeField] private MatchConfigSo _data;

        [SerializeField] private TMP_Text _roundTimeText;

        private ScoreManager _scoreManager;
        private MatchTimer _matchTimer;

        private PlayerType _timeOutWinner;

        private bool _isRoundEnding;

        private int _currentRound;

        private void Awake()
        {
            _scoreManager = new ScoreManager(_data.PointsToWin);
            _matchTimer = new MatchTimer(_data, _roundTimeText);

            MatchEvents.OnGoalZoneReached += PointScored;
            MatchEvents.OnSideChanged += ChangeTimeOutWinner;
            BallEvents.OnBallLaunched += StartTimer;
        }

        private void Start()
        {
            _currentRound = 1;
            MatchEvents.RaiseRoundStarted(_currentRound);            
        }

        private void Update()
        {
            _matchTimer.UpdateTimer();
            CheckForWinner();
        }

        private void OnDestroy()
        {
            MatchEvents.OnGoalZoneReached -= PointScored;
            MatchEvents.OnSideChanged -= ChangeTimeOutWinner;
            BallEvents.OnBallLaunched -= StartTimer;
        }

        private void StartTimer()
        {
            _matchTimer.StartTimer();
        }

        private void ChangeTimeOutWinner(PlayerType playerType)
        {
            _timeOutWinner = playerType;
        }

        private void CheckForWinner()
        {
            if (_matchTimer.CheckTimeLimitReached())
            {
                TryScorePoint(_timeOutWinner);
            }
        }

        private void PointScored(PlayerType playerType)
        {
            TryScorePoint(playerType);
        }

        private void TryScorePoint(PlayerType playerType)
        {
            if (_isRoundEnding) return;

            _isRoundEnding = true;

            StartCoroutine(PointScoredRoutine(playerType));
        }

        private IEnumerator PointScoredRoutine(PlayerType playerType)
        {
            _matchTimer.StopTimer();
            MatchEvents.RaiseRoundFinished();
        
            bool matchFinished = _scoreManager.AddPoint(playerType);

            if (matchFinished)
            {
                yield return MatchFinishedRoutine(playerType);
                yield break;
            }

            AudioEvents.RaiseSFXAudioPlayRequested(AudioType.ScoreUpSound);
            MatchEvents.RaisePointScored(playerType);

            yield return new WaitForSeconds(_data.TimeBetweenRounds);

            _matchTimer.ResetTimer();

            _isRoundEnding = false;

            _currentRound++;
            MatchEvents.RaiseRoundStarted(_currentRound);
        }     
                
        private IEnumerator MatchFinishedRoutine(PlayerType playerType)
        {
            PauseEvents.RaisePauseInputDisableRequest();

            yield return new WaitForSeconds(_data.WinningDisplayDelayTime);

            AudioEvents.RaiseSFXAudioPlayRequested(AudioType.WinSound);
            MatchEvents.RaiseMatchFinished(playerType);

            yield return new WaitForSeconds(_data.WinningDisplayTime);

            SceneTransitionEvents.RaiseSceneChangeRequested(_data.MainMenuScene);
        }
    }
}

