using UnityEngine;
using System.Collections;
using Game.Core;
using Game.Data;
using Game.Events;
using TMPro;

namespace Game.Match
{
    public class MatchManager : MonoBehaviour
    {
        [SerializeField] private MatchConfigSo _data;

        [SerializeField] private TMP_Text _roundTimeText;

        private ScoreManager _scoreManager;
        private MatchTimer _matchTimer;

        private void Awake()
        {
            _scoreManager = new ScoreManager(_data.PointsToWin);
            _matchTimer = new MatchTimer(_data, _roundTimeText);

            MatchEvents.OnPointScored += PointScored;
            BallEvents.OnBallLaunched += StartTimer;
        }

        private void Start()
        {
            MatchEvents.RaiseRoundStarted();            
        }

        private void Update()
        {
            _matchTimer.UpdateTimer();
        }

        private void OnDestroy()
        {
            MatchEvents.OnPointScored -= PointScored;
            BallEvents.OnBallLaunched -= StartTimer;
        }

        private void StartTimer()
        {
            _matchTimer.StartTimer();
        }

        private void PointScored(PlayerType playerType)
        {
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

