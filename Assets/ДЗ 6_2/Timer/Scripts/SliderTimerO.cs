using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    public class SliderTimerO : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private CountdownTimerO _timer;

        public void Initialize(CountdownTimerO timer)
        {
            _timer = timer;

            _timer.Started += OnTimerStarted;
            _timer.Finished += OnTimerFinished;
        }

        private void OnTimerFinished()
        {
           _slider.value = 0;
        }

        private void OnTimerStarted(float duration)
        {
            _slider.maxValue = duration;
            _slider.value = duration;
        }

        private void Update()
        {
            if(_timer != null && _timer.IsRunning)
                _slider.value = _timer.GetRemainingTime();
        }

        private void OnDisable()
        {
            _timer.Started -= OnTimerStarted;
            _timer.Finished -= OnTimerFinished;
        }
    }
}
