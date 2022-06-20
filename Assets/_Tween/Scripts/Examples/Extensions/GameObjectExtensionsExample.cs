using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tween
{

internal class GameObjectExtensionsExample : MonoBehaviour
{
        [Header("Components")]
        [SerializeField] private GameObject _gameObject;

        [Header("Settings")]
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;
        [SerializeField] private float _duration;

        private void Start()
        {
            
            _gameObject.Move(_startPoint.position, _endPoint.position, _duration);
        }
    }
}
