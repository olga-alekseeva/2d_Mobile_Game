using Tools;
using UnityEngine;
using Game.Transport;

namespace Game.Cars.LowRiderClose
{
    internal class LowRiderClosedController : TransportController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Cars/LowRiderClose");
        private readonly CarView _view;

        public override GameObject ViewGameObject => _view.gameObject;

        public LowRiderClosedController()
        {
            _view = LoadView();
        }

        private CarView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);

            return objectView.GetComponent<CarView>();
        }
    }
}