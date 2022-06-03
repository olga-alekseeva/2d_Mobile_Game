using Tools;
using Profile;
using UnityEngine;

namespace UI
{
    internal class BackButtonController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/UI/BackButton");
        private readonly ProfilePlayer _profilePlayer;
        private readonly BackButtonView _backButtonView;

        public BackButtonController (Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _backButtonView = LoadView(placeForUI);
            _backButtonView.Init(BackToMenu);
        }

        private BackButtonView LoadView(Transform placeForUI)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUI, false);
            AddGameObject(objectView);

            return objectView.GetComponent<BackButtonView>();
        }
        private void BackToMenu()
        {
            _profilePlayer.CurrentState.Value = GameState.Start;
        }
    }
}
