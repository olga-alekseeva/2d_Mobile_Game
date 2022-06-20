using System;
using System.Collections;
using UnityEngine;

namespace Tween
{
    internal enum RatioType
    {
        Linear,
        Quad,
        Root
    }
    internal class VectorLerpComponent: MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endTransform;
        [SerializeField] private RatioType _ratioType;

        public void Play(Vector3 startPosition, Vector3 endPosition, float duration)
        {
            Stop();
            _coroutine = StartCoroutine(Playing(startPosition, endPosition, _duration));
        }

        private Coroutine _coroutine;

        [ContextMenu(nameof(Play))]
        public void Play()
        {
            Vector3 startPosition = _startPoint.position;
            Vector3 endPosition = _endTransform.position;
            Play(startPosition, endPosition, _duration);
            
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
            transform.position = _startPoint.position;
        }
        private IEnumerator Playing(Vector3 startPosition, Vector3 endPosition, float duration)
        {
            for (float t = 0; t < _duration; t += Time.deltaTime)
            {
                float ratio = CalcRatio(t);
                transform.position = Vector3.Lerp(startPosition, endPosition, ratio);
                yield return null;
            }
            transform.position = endPosition;
        }
        private float CalcRatio(float time)
        {
            var x = time / _duration;

            return _ratioType switch
            {
                RatioType.Linear => x,
                RatioType.Quad => MathF.Pow(x, 2),
                RatioType.Root => MathF.Sqrt(x),
                _ => throw new ArgumentOutOfRangeException()
            };
            return Mathf.Pow(x,2);
        }
    }
}
