using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timer
{
    public class HeartsTimerO : MonoBehaviour
    {
        [SerializeField] private GameObject _heartPrefab;
        [SerializeField] private Transform _heartsContainer;

        private CountdownTimerO _timer;
        private List<GameObject> _hearts = new List<GameObject>();

        public void Initialize(CountdownTimerO timer)
        {
            _timer = timer;
            _timer.Started += OnTimerStarted;
        }

        private void OnTimerStarted(float duration)
        {
            Debug.Log(duration);

            ClearHearts();
            GenerateHearts((int)duration);

            StartCoroutine(HeartUpdater());
        }

        private void GenerateHearts(int count)
        {
            for (int i = 1; i < count; i++)
            {
                GameObject newHeart = Instantiate(_heartPrefab, _heartsContainer);
                _hearts.Add(newHeart);
            }
        }

        private void ClearHearts()
        {
            foreach (GameObject heart in _hearts)
            {
                Destroy(heart);
            }

            _hearts.Clear();
        }

        private IEnumerator HeartUpdater()
        {
            while (_timer != null && _timer.IsRunning)
            {
                float remainingTime = _timer.GetRemainingTime();
                int remainingHearts = Mathf.CeilToInt(remainingTime);

                while (_hearts.Count > remainingHearts)
                {
                    Destroy(_hearts[_hearts.Count - 1]);
                    _hearts.RemoveAt(_hearts.Count - 1);
                }

                yield return new WaitForSeconds(1f);
            }
        }

        private void OnDisable()
        {
            if (_timer != null)
            {
                _timer.Started -= OnTimerStarted;
            }
        }
    }
}
