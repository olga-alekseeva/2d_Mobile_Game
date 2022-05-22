using Tools;
using UnityEngine;


namespace Game.Cars.LowRiderClose
{


    internal class LowRiderClosedController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Cars/LowRiderClose");
        private readonly CarView _view;


        public GameObject ViewGameObject => _view.car;


        public LowRiderClosedController()
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
