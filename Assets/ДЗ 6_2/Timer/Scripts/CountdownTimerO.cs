using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timer
{
    public class CountdownTimerO
    {
        public event Action Finished;
        public event Action<float> Started;

        private float _remainingTime;
        private MonoBehaviour _context;
        private Coroutine _timerCoroutine;

        public CountdownTimerO(MonoBehaviour context)
        {
            _context = context;
        }

        public bool IsRunning { get; private set; }

        public void StartTimer(float duration)
        {
            StopTimer();

            _remainingTime = duration;
            _timerCoroutine = _context.StartCoroutine(TimerCoroutine());
            IsRunning = true;

            Started?.Invoke(duration);
        }

        public void StopTimer()
        {
            if (_timerCoroutine != null)
            {
                _context.StopCoroutine(_timerCoroutine);
                _timerCoroutine = null;
            }

            IsRunning = false;
        }

        public void ContinueTimer()
        {
            if (_remainingTime <= 0 && IsRunning)
                return;

            _timerCoroutine = _context.StartCoroutine(TimerCoroutine());
            IsRunning = true;
        }

        public void ResetTimer()
        {
            StopTimer();

            _remainingTime = 0f;

            Finished?.Invoke();
        }

        public float GetRemainingTime() => Mathf.Max(_remainingTime, 0f);

        private IEnumerator TimerCoroutine()
        {
            while (_remainingTime > 0)
            {
                _remainingTime -= Time.deltaTime;
                yield return null;
            }

            Finished?.Invoke();

            ResetTimer();
        }

    }
}
