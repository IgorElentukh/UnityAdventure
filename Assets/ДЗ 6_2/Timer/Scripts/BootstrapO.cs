using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timer
{
    public class BootstrapO : MonoBehaviour
    {
        [SerializeField] private SliderTimerO _slider;
        [SerializeField] private HeartsTimerO _hearts;

        private CountdownTimerO _timer;

        private void Awake()
        {
            _timer = new CountdownTimerO(this);

            _slider = Instantiate(_slider);
            _slider.Initialize(_timer);

            _hearts = Instantiate(_hearts);
            _hearts.Initialize(_timer);

            _timer.StartTimer(10);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                _timer.StopTimer();
            else if(Input.GetKeyDown(KeyCode.C))
                _timer.ContinueTimer();
            else if(Input.GetKeyDown(KeyCode.R))
                _timer.ResetTimer();
        }
    }
}
