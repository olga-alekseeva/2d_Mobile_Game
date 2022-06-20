using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Tween
{
    internal class MainWindowView : MonoBehaviour
    {
        [Header("Popup")]
        [SerializeField] private Button _openPopupButton;
        [SerializeField] private PopupView _popupView;

        [Header("Change Text")]
        [SerializeField] private Button _buttonChangeText;
        [SerializeField] private Text _changeableText;
        [SerializeField] private string _newText;
        [SerializeField] private Ease _textEaseType;
        [SerializeField] private float _textDuration;


        private void Start()
        {
            _openPopupButton.onClick.AddListener(_popupView.ShowPopup);
            _buttonChangeText.onClick.AddListener(ChangeText);
        }

        private void OnDestroy()
        {
            _openPopupButton.onClick.RemoveAllListeners();
            _buttonChangeText.onClick.RemoveAllListeners();
        }


        private void ChangeText() =>
            _changeableText.DOText(_newText, _textDuration).SetEase(_textEaseType);
    }
}
