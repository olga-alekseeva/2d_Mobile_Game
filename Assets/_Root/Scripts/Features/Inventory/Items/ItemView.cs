﻿using Tools;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Features.Inventory.Items
{
    internal class ItemView : MonoBehaviour, IItemView
    {
        [Header("Components")]
        [SerializeField] private Image _icon;
        [SerializeField] private CustomText _text;
        [SerializeField] private Button _button;
        [Header("Backgrounds")]
        [SerializeField] private GameObject _selectedBackground;
        [SerializeField] private GameObject _unselectedBackground;

        private void OnDestroy() => Deinit();
        public void Init(IItem item, UnityAction clickAction)
        {
            _text.Text = item.Info.Title;
            _icon.sprite = item.Info.Icon;
            _button.onClick.AddListener(clickAction);
        }
        public void Deinit()
        {
            _text.Text = string.Empty;
            _icon.sprite = null;
            _button.onClick.RemoveAllListeners();
        }

        public void Select() => SetSelected(true);
        public void Unselect() => SetSelected(false);


        private void SetSelected(bool isSelected)
        {
            _selectedBackground.SetActive(isSelected);
            _unselectedBackground.SetActive(!isSelected);
        }
    }
}
