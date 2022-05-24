using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonAds;


        public void Init(UnityAction startGame, UnityAction showAds)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonAds.onClick.AddListener(showAds);

        }

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonAds.onClick.RemoveAllListeners();

        }
        
    }
}
