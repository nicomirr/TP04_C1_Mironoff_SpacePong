using UnityEngine;
using Game.Core;
using Game.Data;
using Game.Events;
using System.Collections;

//FALTA QUE AL TERMINAR VUELVA AL MENU
//FALTA QUE AL PASAR 20 SEGUNDOS SE ANOTE PUNTO (USAR TIMER)

namespace Game.Match
{
    public class MatchManager : MonoBehaviour
    {
        [SerializeField] private MatchConfigSo _data;

        private ScoreManager _scoreManager;

        private void Awake()
        {
            _scoreManager = new ScoreManager(_data.PointsToWin);

            MatchEvents.OnPointScored += PointScored;
        }

        private void Start()
        {
            MatchEvents.RaiseRoundStarted();
        }

        private void OnDestroy()
        {
            MatchEvents.OnPointScored -= PointScored;
        }

        private void PointScored(PlayerType playerType)
        {
            StartCoroutine(PointScoredRoutine(playerType));
        }

        private IEnumerator PointScoredRoutine(PlayerType playerType)
        {
            MatchEvents.RaiseRoundFinished();

            bool matchFinished = _scoreManager.AddPoint(playerType);

            if (matchFinished)
            {
                MatchEvents.RaiseMatchFinished(playerType);
                yield break;
            }

            yield return new WaitForSeconds(_data.TimeBetweenRounds);

            MatchEvents.RaiseRoundStarted();
        }

    }
}

