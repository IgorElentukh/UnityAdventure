using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timer
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private SliderTimerDisplay _slider;
        [SerializeField] private HeartTimerDisplay _hearts;

        private CountdownTimer _timer;

        private void Awake()
        {
            _timer = new CountdownTimer(this);

            _slider = Instantiate(_slider);
            _slider.Initialize(_timer);

            _hearts = Instantiate(_hearts);
            _hearts.Initialize(_timer);

            _timer.StartTimer(10);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                _timer.StopTimer();
            else if (Input.GetKeyDown(KeyCode.D))
                _timer.ContinueTimer();
            else if (Input.GetKeyDown(KeyCode.A))
                _timer.ResetTimer();
        }
    }
}
