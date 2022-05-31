using UnityEngine;

namespace Features.AbilitySystem
{
    internal interface IAbilityActivator
    {
        GameObject ViewGameObject { get; }
        public float jumpHeight { get; set; }
    }
}
