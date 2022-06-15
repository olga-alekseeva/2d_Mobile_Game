using Profile;
using UnityEngine;

namespace Game
{
    internal interface IStartSettingsItem
    {
        float SpeedCar { get; }
        float JumpHeightCar { get; }
        GameState InitialState { get; }
        TransportType TransportType { get; }
    }
    [CreateAssetMenu(fileName = nameof(StartConfig), menuName = "Config/" + nameof(StartConfig))]
    internal class StartConfig : ScriptableObject, IStartSettingsItem
    {
        [field: SerializeField, Range(0f, 80f)]
        public float SpeedCar { get; private set; }

        [field: SerializeField, Range(0f, 100f)]
        public float JumpHeightCar { get; private set; }

        public GameState InitialState => GameState.Start;
        public TransportType TransportType => Game.TransportType.RacingCar;

    }
}
