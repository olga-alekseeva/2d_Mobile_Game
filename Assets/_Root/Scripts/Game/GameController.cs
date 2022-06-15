using Features.AbilitySystem;
using Game.Cars.LowRiderClose;
using Game.Cars.RacingCar;
using Game.InputLogic;
using Game.TapeBackground;
using Game.Transport;
using Profile;
using Services;
using System;
using Tools;
using UnityEngine;

namespace Game
{
    internal class GameController : BaseController
    {
        private readonly ProfilePlayer _profilePlayer;
        private readonly SubscriptionProperty<float> _leftMoveDiff;
        private readonly SubscriptionProperty<float> _rightMoveDiff;

        private readonly AbilitiesControllerFactory _abilitiesFactory;
        private readonly TapeBackgroundController _tapeBackgroundController;
        private readonly InputGameController _inputGameController;
        private readonly TransportController _transportController;
        private readonly AbilitiesController _abilitiesController;
        public GameController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _leftMoveDiff = new SubscriptionProperty<float>();
            _rightMoveDiff = new SubscriptionProperty<float>();

            _tapeBackgroundController = CreateTapeBackground();
            _inputGameController = CreateInputGameController();
            _transportController = CreateTransportController();

            _abilitiesFactory = new AbilitiesControllerFactory(_transportController);
            _abilitiesController = _abilitiesFactory.Create(placeForUI);

            ServiceRoster.Analytics.SendGameStarted();

        }
        protected override void OnDispose()
        {
            _abilitiesFactory.Dispose();
        }
        private TapeBackgroundController CreateTapeBackground()
        {
            var tapeBackgroundController = new TapeBackgroundController(_leftMoveDiff, _rightMoveDiff);
            AddController(tapeBackgroundController);

            return tapeBackgroundController;
        }
        private InputGameController CreateInputGameController()
        {
            var inputGameController = new InputGameController(_leftMoveDiff, _rightMoveDiff, _profilePlayer.CurrentTransport);
            AddController(inputGameController);

            return inputGameController;
        }
        private TransportController CreateTransportController()
        {
            TransportController transportController =
                _profilePlayer.CurrentTransport.Type switch
                {
                    TransportType.RacingCar => new RacingCarController(),
                    TransportType.LowriderCar => new LowRiderClosedController(),
                    _ => throw new ArgumentException(nameof(TransportType))
                };

            AddController(transportController);

            return transportController;
        }       
       
    }
}
