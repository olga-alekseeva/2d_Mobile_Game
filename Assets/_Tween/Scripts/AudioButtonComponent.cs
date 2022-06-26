using UnityEngine;
using UnityEngine.UI;

namespace Tween
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(RectTransform))]
    public class AudioButtonComponent : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private RectTransform _rectTransform;

        private void OnValidate() => InitComponents();
        private void Awake() => InitComponents();

        private void Start() => _button.onClick.AddListener(OnButtonClick);
        private void OnDestroy() => _button.onClick.RemoveAllListeners();

        private void InitComponents()
        {
            _button ??= GetComponent<Button>();
            _audioSource ??= GetComponent<AudioSource>();
            _rectTransform ??= GetComponent<RectTransform>();
        }
        private void OnButtonClick()
        {
            PlaySound();
        }
        private void PlaySound() => _audioSource.Play();
    }
}
