using Game;
using Profile;
using UnityEngine;
using Services.Analytics;

internal class EntryPoint : MonoBehaviour
{
    [Header("Initial Settings")]
    private const float SpeedCar = 15f;
    private const float JumpHeightCar = 8f;
    private const GameState InitialState = GameState.Start;
    private const TransportType TransportType = Game.TransportType.RacingCar;
    private MainController _mainController;
    private TransportType _carType;

    [SerializeField] private Transform _placeForUI;
    
    private void Start()
    {
        var profilePlayer = new ProfilePlayer(SpeedCar, JumpHeightCar,TransportType, InitialState);
        _mainController = new MainController(_placeForUI, profilePlayer);
    }
    private void OnDestroy()
    { 
        _mainController.Dispose();
    } 
}