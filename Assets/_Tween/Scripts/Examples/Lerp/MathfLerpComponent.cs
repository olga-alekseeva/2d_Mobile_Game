using UnityEngine;
using System.Collections;

namespace Tween
{
    internal class MathfLerpComponent : MonoBehaviour
    {
        private const int MinValue = 0;
        private const int MaxValue = 100;

        [SerializeField, Range(MinValue, MaxValue)] private float _range;
        [SerializeField] private float _duration;
        private Coroutine _coroutine;

        [ContextMenu(nameof(Play))]
        public void Play()
        {
            Stop();
            _coroutine = StartCoroutine(Playing());
        }
        [ContextMenu(nameof(Stop))]
        public void Stop()
        {
            if (_coroutine == null)
                return;
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        public void Reset()
        {
            Stop();
            _range = MinValue;
        }
        private IEnumerator Playing()
        {
            for (float t = 0; t < _duration; t += Time.deltaTime)
            {
                float ratio = CalcRatio(t);
                _range = Mathf.Lerp(MinValue, MaxValue, ratio);
                yield return null;
            }
            _range = MaxValue;
        }

        private float CalcRatio(float time)
        {
            return time / _duration;
        }
    }
}
