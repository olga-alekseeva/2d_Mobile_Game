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
        private MainMenuController _mainMenuController;

        public void Init(UnityAction startGame, UnityAction showAds, UnityAction buyBomb, UnityAction shed)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonAds.onClick.AddListener(showAds);
            _buttonBuyBomb.onClick.AddListener(buyBomb);
            _buttonShed.onClick.AddListener(shed);
        }

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonAds.onClick.RemoveAllListeners();
            _buttonBuyBomb.onClick.RemoveAllListeners();
            _buttonShed.onClick.RemoveAllListeners();
        }
    }
}