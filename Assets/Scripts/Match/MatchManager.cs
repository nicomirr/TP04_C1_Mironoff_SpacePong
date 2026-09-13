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

        private void Awake()
        {
            _scoreManager = new ScoreManager(_data.PointsToWin);
            _matchTimer = new MatchTimer(_data, _roundTimeText);

            MatchEvents.OnPointScored += PointScored;
            MatchEvents.OnSideChanged += ChangeTimeOutWinner;
            BallEvents.OnBallLaunched += StartTimer;
        }

        private void Start()
        {
            MatchEvents.RaiseRoundStarted();            
        }

        private void Update()
        {
            _matchTimer.UpdateTimer();
            CheckForWinner();
        }

        private void OnDestroy()
        {
            MatchEvents.OnPointScored -= PointScored;
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

            yield return new WaitForSeconds(_data.TimeBetweenRounds);

            _matchTimer.ResetTimer();

            _isRoundEnding = false;

            MatchEvents.RaiseRoundStarted();
        }     
        
        private IEnumerator MatchFinishedRoutine(PlayerType playerType)
        {
            PauseEvents.RaisePauseInputDisableRequest();

            yield return new WaitForSeconds(_data.WinningDisplayDelayTime);

            MatchEvents.RaiseMatchFinished(playerType);

            yield return new WaitForSeconds(_data.WinningDisplayTime);

            SceneTransitionEvents.RaiseSceneChangeRequested(_data.MainMenuScene);
        }
    }
}

