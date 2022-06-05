using Features.Inventory;
using Features.Shed;
using Game;
using Profile;
using UI;
using UnityEngine;

internal class MainController : BaseController
{
    private readonly Transform _placeForUI;
    private readonly ProfilePlayer _profilePlayer;

    private MainMenuController _mainMenuController;
    private SettingsMenuController _settingsMenuController;
    private GameController _gameController;
    private InventoryController _inventoryController;
    private ShedController _shedController;
    private BackButtonController _backButtonController;

    public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _placeForUI = placeForUi;
        _profilePlayer = profilePlayer;
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    protected override void OnDispose()
    {
        DisposeAllControllers();
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
        
    }

    private void OnChangeGameState(GameState state)
    {
                DisposeAllControllers();
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUI, _profilePlayer);
                break;

            case GameState.Settings:
                _settingsMenuController = new SettingsMenuController(_placeForUI, _profilePlayer);
                break;

            case GameState.Game:
                _gameController = new GameController(_placeForUI,_profilePlayer);
                _backButtonController = new BackButtonController(_placeForUI,_profilePlayer);               
                break;
            case GameState.Shed:
                _shedController = new ShedController(_placeForUI, _profilePlayer);
                break;

            default:
                break;
        }
    }

    private void DisposeAllControllers()
    {
        _mainMenuController?.Dispose();
        _backButtonController?.Dispose();
        _gameController?.Dispose();
        _settingsMenuController?.Dispose();
        _shedController?.Dispose();
    }
}