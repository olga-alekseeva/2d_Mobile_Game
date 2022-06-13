﻿using UnityEngine;

namespace Rewards
{
    internal class CurrencyView:MonoBehaviour
    {
        private const string WoodKey = nameof(WoodKey);
        private const string DiamondKey = nameof(DiamondKey);

        private static CurrencyView _instance;
        public static CurrencyView  Instance => _instance;
        [SerializeField] private CurrencySlotView _currencyWood;
        [SerializeField] private CurrencySlotView _currencyDiamond;
        private int Wood
        {
            get => PlayerPrefs.GetInt(WoodKey);
            set => PlayerPrefs.SetInt(WoodKey, value);
            
        }
        private int Diamond
        { get => PlayerPrefs.GetInt(DiamondKey);
          set => PlayerPrefs.SetInt (DiamondKey, value);
         
        }
        private void Awake() =>
            _instance = this;
        private void OnDestroy() =>
            _instance = null;

        private void Start()
        {
            _currencyWood.SetData(Wood);
            _currencyDiamond.SetData(Diamond);
        }
        public void AddWood(int count)
        {
            Wood += count;
            _currencyWood.SetData(Wood);
        }

        public void AddDiamond(int count)
        {
            Diamond += count;
            _currencyDiamond.SetData(Diamond);
        }
    }
}
