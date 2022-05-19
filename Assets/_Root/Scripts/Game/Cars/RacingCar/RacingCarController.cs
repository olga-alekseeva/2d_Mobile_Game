using Tools;
using UnityEngine;

namespace Game.Cars.RacingCar
{
    internal class RacingCarController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Racing Car");
        private readonly CarView _view;

        public GameObject ViewGameObject => _view.car;

        public RacingCarController()
        {
            _view = LoadView();
        }

        private CarView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);

            return objectView.GetComponent<CarView>();
        }
    }
}