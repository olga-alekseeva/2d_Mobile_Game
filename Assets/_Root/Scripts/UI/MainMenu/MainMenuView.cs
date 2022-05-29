using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonAds;
        [SerializeField] private Button _buttonBuyBomb;
        [SerializeField] private Button _buttonShed;
        [SerializeField] private Button _buttonSettings;
        private MainMenuController _mainMenuController;

        public void Init(UnityAction startGame, UnityAction showAds, UnityAction buyBomb,
            UnityAction shed, UnityAction settings)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonAds.onClick.AddListener(showAds);
            _buttonBuyBomb.onClick.AddListener(buyBomb);
            _buttonShed.onClick.AddListener(shed);
            _buttonSettings.onClick.AddListener(settings);
        }

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonAds.onClick.RemoveAllListeners();
            _buttonBuyBomb.onClick.RemoveAllListeners();
            _buttonShed.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
        }
    }
}