using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timer
{
    public class HeartTimerDisplay : MonoBehaviour, ITimerDisplay
    {
        [SerializeField] private GameObject _heartPrefab;
        [SerializeField] private Transform _container;
        [SerializeField] private float _spacing = 10f;

        private CountdownTimer _timer;
        private List<GameObject> _hearts = new List<GameObject>();

        public void Initialize(CountdownTimer timer)
        {
            _timer = timer;

            _timer.Started += OnTimerStarted;
            _timer.Updated += OnTimeUpdated;
            _timer.Finished += OnTimerFinished;
        }

        public void OnTimerStarted(float duration)
        {
            foreach (var heart in _hearts)
            {
                Destroy(heart);
            }
            _hearts.Clear();

            for (int i = 0; i < Mathf.CeilToInt(duration); i++)
            {
                var heart = Instantiate(_heartPrefab, _container);
                var rectTransform = heart.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(i * _spacing, 0);
                _hearts.Add(heart);
            }
        }

        public void OnTimeUpdated(float remainingTime)
        {
            int heartsToKeep = Mathf.CeilToInt(remainingTime);

            for (int i = 0; i < _hearts.Count; i++)
            {
                _hearts[i].SetActive(i < heartsToKeep);
            }
        }

        public void OnTimerFinished()
        {
            foreach (var heart in _hearts)
            {
                heart.SetActive(false);
            }
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
