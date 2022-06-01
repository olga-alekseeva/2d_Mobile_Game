using Tools;
using Profile;
using Services;
using UnityEngine;
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

        public MainMenuController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUI);
            _view.Init(StartGame, Settings, ShowShed, ShowAds, BuyProduct);
            SubscribeAds();
            SubscribeIAP();
        }
        protected override void OnDispose()
        {
            UnsubscribeAds();
            UnsubscribeIAP();
        }


        private MainMenuView LoadView(Transform placeForUI)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUI, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainMenuView>();
        }
        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
           _profilePlayer.CurrentState.Value = GameState.Settings;
        }  
        private void ShowShed()
        {
            _profilePlayer.CurrentState.Value = GameState.Shed;
        }
        private void Settings()
        {
            _profilePlayer.CurrentState.Value = GameState.Settings;
        }
        public void BuyProduct(string productId) =>
          ServiceRoster.IAPService.Buy(productId);

        private void ShowAds() =>
           ServiceRoster.AdsService.RewardedPlayer.Play();
        private void SubscribeAds()
        {
            ServiceRoster.AdsService.RewardedPlayer.Finished += OnAdsFinished;
            ServiceRoster.AdsService.RewardedPlayer.Failed += OnAdsCancelled;
            ServiceRoster.AdsService.RewardedPlayer.Skipped += OnAdsCancelled;
        }

        private void UnsubscribeAds()
        {
            ServiceRoster.AdsService.RewardedPlayer.Finished -= OnAdsFinished;
            ServiceRoster.AdsService.RewardedPlayer.Failed -= OnAdsCancelled;
            ServiceRoster.AdsService.RewardedPlayer.Skipped -= OnAdsCancelled;
        }

        private void SubscribeIAP()
        {
            ServiceRoster.IAPService.PurchaseSucceed.AddListener(OnIAPSucceed);
            ServiceRoster.IAPService.PurchaseFailed.AddListener(OnIAPFailed);
        }

        private void UnsubscribeIAP()
        {
            ServiceRoster.IAPService.PurchaseSucceed.RemoveListener(OnIAPSucceed);
            ServiceRoster.IAPService.PurchaseFailed.RemoveListener(OnIAPFailed);
        }

        private void OnAdsFinished() => Log("You've received a reward for ads!");
        private void OnAdsCancelled() => Log("Receiving a reward for ads has been interrupted!");

        private void OnIAPSucceed() => Log("Purchase succeed");
        private void OnIAPFailed() => Log("Purchase failed");
    }
}
