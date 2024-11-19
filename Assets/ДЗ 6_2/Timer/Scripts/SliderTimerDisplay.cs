using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    public class SliderTimerDisplay : MonoBehaviour, ITimerDisplay
    {
        [SerializeField] private Slider _slider;

        private CountdownTimer _timer;

        public void Initialize(CountdownTimer timer)
        {
            _timer = timer;

            _timer.Started += OnTimerStarted;
            _timer.Updated += OnTimeUpdated;
            _timer.Finished += OnTimerFinished;
        }

        public void OnTimerStarted(float duration)
        {
            _slider.maxValue = duration;
            _slider.value = duration;
        }

        public void OnTimeUpdated(float remainingTime)
        {
            if (_timer != null && _timer.IsRunning)
                _slider.value = remainingTime;
        }

        public void OnTimerFinished()
        {
            _slider.value = 0;
        }

        private void Update()
        {
            OnTimeUpdated(_timer.GetRemainingTime());
        }

        private void OnDisable()
        {
            if (_timer != null)
            {
                _timer.Started -= OnTimerStarted;
                _timer.Updated -= OnTimeUpdated;
                _timer.Finished -= OnTimerFinished;
            }
        }
    }
}
