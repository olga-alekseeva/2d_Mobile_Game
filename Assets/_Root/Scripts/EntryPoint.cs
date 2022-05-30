using Game;
using Profile;
using UnityEngine;
using Services.IAP;
using Services.Analytics;
using Services.Ads.UnityAds;
using UnityEngine.Advertisements;

internal class EntryPoint : MonoBehaviour, IUnityAdsInitializationListener
{
    private const float SpeedCar = 15f;
    private const GameState InitialState = GameState.Start;
    private const TransportType TransportType = Game.TransportType.RacingCar;
    private MainController _mainController;
    private TransportType _carType;

    [SerializeField] private Transform _placeForUI;
    [SerializeField] private AnalyticsManager _analytics;
    [SerializeField] private UnityAdsService _adsService;
    [SerializeField] private IAPService _iapService;

    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(SpeedCar, TransportType, InitialState);
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

    public void OnIapInitialized() => _iapService.Buy("product_1");
}