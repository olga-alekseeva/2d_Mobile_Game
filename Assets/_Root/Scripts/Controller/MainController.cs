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

    public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _placeForUI = placeForUi;
        _profilePlayer = profilePlayer;

        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _settingsMenuController?.Dispose();
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
        _inventoryController?.Dispose();
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUI, _profilePlayer);
                _settingsMenuController?.Dispose();
                _shedController?.Dispose();
                _gameController?.Dispose();
                break;

            case GameState.Settings:
                _settingsMenuController = new SettingsMenuController(_placeForUI, _profilePlayer);
                _shedController?.Dispose();
                break;

            case GameState.Game:
                _gameController = new GameController(_placeForUI,_profilePlayer);
                _mainMenuController?.Dispose();
                _settingsMenuController?.Dispose();
                _shedController?.Dispose();
                break;
            case GameState.Shed:
                _shedController = new ShedController(_placeForUI, _profilePlayer);
                _gameController?.Dispose();
                _settingsMenuController?.Dispose();
                _mainMenuController?.Dispose();
                break;

            default:
                _mainMenuController?.Dispose();
                _settingsMenuController?.Dispose();
                _gameController?.Dispose();
                _shedController?.Dispose();
                break;
        }
    }
}