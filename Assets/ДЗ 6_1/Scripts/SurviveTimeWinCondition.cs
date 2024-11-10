using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates.Events
{
    public class SurviveTimeWinCondition : IWinCondition
    {
        public event Action WinAchieved;

        private float _timeToWin;
        private float _timer = 0f;

        public SurviveTimeWinCondition(float timeToWin)
        {
            _timeToWin = timeToWin;
        }

        public void CheckWinCondition()
        {
            _timer += Time.deltaTime;

            if(_timer >= _timeToWin)
                WinAchieved?.Invoke();

        }
    }
}
