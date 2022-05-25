using Profile;
using Tools;
using UnityEngine;
using UnityEngine.Advertisements;
using Services.IAP;
using Object = UnityEngine.Object;

namespace UI

{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/UI/MainMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;
        private readonly SettingsMenuView _settingsView;
        private readonly IAPService _iapService;
        private readonly EntryPoint _entryPoint;


        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame,ShowAds, BuyBomb);
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObjects(objectView);

            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
             _profilePlayer.CurrentState.Value = GameState.Game;
            _profilePlayer.CurrentState.Value = GameState.Settings;
        }

        private void ShowAds()
        {
            Advertisement.Load("Rewarded_Android");
            Advertisement.Show("Rewarded_Android");
            Advertisement.Load("Rewarded_Android");
        }

        public void BuyBomb()
        {
        _iapService.Buy("product_1");

        }

    }
}
