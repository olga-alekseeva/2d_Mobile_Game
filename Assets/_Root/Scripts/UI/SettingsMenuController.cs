﻿using Profile;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI
{
    internal class SettingsMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/UI/Settings");
        private readonly ProfilePlayer _profilePlayer;
        private readonly SettingsMenuView _settingsMenuView;

        public SettingsMenuController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _settingsMenuView = LoadView(placeForUI);
            _settingsMenuView.Init(ShowStart);
        }

        private SettingsMenuView LoadView(Transform placeForUI)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUI, false);
            AddGameObject(objectView);

            return objectView.GetComponent<SettingsMenuView>();
        }

        private void ShowStart() => _profilePlayer.CurrentState.Value = GameState.Start;
    }
}