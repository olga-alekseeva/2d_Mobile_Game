using Game;
using Profile;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    
    [SerializeField] private CarConfig _carConfig;
    [SerializeField] private Transform _placeForUI;
    private MainController _mainController;
    
    private void Start()
    {
        var profilePlayer = new ProfilePlayer(_carConfig.SpeedCar,
            _carConfig.JumpHeightCar, _carConfig.TransportType, _carConfig.InitialState);
        _mainController = new MainController(_placeForUI, profilePlayer);
    }
    private void OnDestroy()
    { 
        _mainController.Dispose();
    } 
}