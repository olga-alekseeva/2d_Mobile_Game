using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UI
{
    public class BackButtonView : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _buttonBack;

        public void Init(UnityAction backToMenu) =>
             _buttonBack.onClick.AddListener(backToMenu);

        public void OnDestroy() =>
           _buttonBack.onClick.RemoveAllListeners();
    }
}
