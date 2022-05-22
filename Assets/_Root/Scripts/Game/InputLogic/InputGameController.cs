﻿using Game.Cars.RacingCar;
using Game.Cars;
using Profile;
using Tools;
using UnityEngine;


namespace Game.InputLogic
{
    internal class InputGameController:BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/Input/ArrowInput");
        private BaseInputView _view;


        public InputGameController(
            SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove,
            CarModel car)
        {
            _view = LoadView();
            _view.Init(leftMove, rightMove, car.Speed);
        }

        private BaseInputView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);

            BaseInputView view = objectView.GetComponent<BaseInputView>();
            return view;
        }
    }
}
