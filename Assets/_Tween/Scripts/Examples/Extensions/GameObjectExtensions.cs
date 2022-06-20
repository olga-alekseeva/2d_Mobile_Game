using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tween
{
    internal static class GameObjectExtensions
    {
        public static void Move(this GameObject go, Vector3 startPosition, Vector3 endPosition, float duration)
        {
            if(go.TryGetComponent(out VectorLerpComponent component))
                component.Play(startPosition, endPosition, duration);   
        }
    }
}
