using UnityEngine;
using System;
using System.Collections.Generic;
using Game.Core;
using Game.Events;
using System.Collections;

namespace Game.Match
{
    public class MatchManager : MonoBehaviour
    {
        [SerializeField] private int _pointsToWin;
        private Dictionary<PlayerType, int> _scores = new Dictionary<PlayerType, int>();

        private void Awake()
        {
            MatchEvents.OnPointScored += PointScored;
        }

        private void Start()
        {
            MatchEvents.RaiseRoundStarted();

            foreach (PlayerType playerType in Enum.GetValues(typeof(PlayerType)))
            {
                _scores.Add(playerType, 0);
            }
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
            AddPoints(playerType);
            MatchEvents.RaiseRoundFinished();

            yield return new WaitForSeconds(2);

            MatchEvents.RaiseRoundStarted();
        }

        private void AddPoints(PlayerType playerType)
        {
            _scores[playerType] ++;
            //CheckForWinner();
        }



        //private void CheckForWinner()
        //{
        //    foreach (KeyValuePair<PlayerType,int> pair in _scores)
        //    {
        //        if(pair.Value >= _pointsToWin) 

        //    }
        //}

    }
}

