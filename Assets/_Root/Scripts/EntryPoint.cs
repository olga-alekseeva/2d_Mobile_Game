using Profile;
using Services.Ads.UnityAds;
using Services.Analytics;
using Services.IAP;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;

internal class EntryPoint : MonoBehaviour, IUnityAdsInitializationListener
{
    private const float SpeedCar = 15f;
    private const GameState InitialState = GameState.Start;
    private MainController _mainController;
    private CarState _carState;

    [SerializeField] private Transform _placeForUI;
    [SerializeField] private AnalyticsManager _analytics;
    [SerializeField] private UnityAdsService _adsService;
    [SerializeField] private IAPService _iapService;


    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(SpeedCar, InitialState, CarState.RacingCar);
        _mainController = new MainController(_placeForUI, profilePlayer);

        if (_adsService.IsInitialized) OnAdsInitialized();
        else _adsService.Initialized.AddListener(OnAdsInitialized);

        if (_iapService.IsInitialized) OnIapInitialized();
        else _iapService.Initialized.AddListener(OnIapInitialized);

        _analytics.SendGameStarted();

        Advertisement.Initialize("4766991", true, this);
           
    }
    public void OnInitializationComplete()
    {
        Advertisement.Load("Interstitial_Android");
        Advertisement.Show("Interstitial_Android");
        Advertisement.Load("Interstitial_Android");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
       
    }

    private void OnDestroy()
    {
        _adsService.Initialized.RemoveListener(OnAdsInitialized);
        _iapService.Initialized.RemoveListener(OnIapInitialized);
        _mainController.Dispose();
    }


    private void OnAdsInitialized() => _adsService.InterstitialPlayer.Play();
    private void OnIapInitialized() => _iapService.Buy("product_1");
}


