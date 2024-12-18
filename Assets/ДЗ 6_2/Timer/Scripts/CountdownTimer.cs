using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timer
{
    public class CountdownTimer
    {
        public event Action<float> Started;
        public event Action Finished;
        public event Action<float> Updated;

        private float _remainingTime;
        private MonoBehaviour _context;
        private Coroutine _timerCoroutine;

        public CountdownTimer(MonoBehaviour context)
        {
            _context = context;
        }

        public bool IsRunning { get; private set; }

        public void StartTimer(float duration)
        {
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
            if (_remainingTime <= 0 || IsRunning)
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

        public float GetRemainingTime() => _remainingTime;

        private IEnumerator TimerCoroutine()
        {
            while (_remainingTime > 0)
            {
                _remainingTime -= Time.deltaTime;
                Updated?.Invoke(_remainingTime);
                yield return null;
            }

            Finished?.Invoke();
            ResetTimer();
        }
    
    }
}
