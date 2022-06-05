using Profile;
using UnityEngine;

namespace Game
{
[CreateAssetMenu(fileName = nameof(CarConfig), menuName = "Config/" + nameof(CarConfig))]
    internal class CarConfig:ScriptableObject
    {
        [SerializeField, Range (0f, 80f) ]
        public float SpeedCar;

        [SerializeField, Range(0f, 10f)]
        public float JumpHeightCar;

        public GameState InitialState = GameState.Start;
        public TransportType TransportType = Game.TransportType.RacingCar;
    }
}
