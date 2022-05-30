using Tools;
using System;
using Profile;
using UnityEngine;
using Game.Transport;
using Game.InputLogic;
using Game.Cars.RacingCar;
using Game.TapeBackground;
using Features.AbilitySystem;
using Game.Cars.LowRiderClose;

namespace Game
{
    internal class GameController : BaseController
    {
        private readonly ProfilePlayer _profilePlayer;
        private readonly SubscriptionProperty<float> _leftMoveDiff;
        private readonly SubscriptionProperty<float> _rightMoveDiff;

        private readonly TapeBackgroundController _tapeBackgroundController;
        private readonly InputGameController _inputGameController;
        private readonly TransportController _transportController;
        private readonly AbilitiesController _abilitiesController;
        public GameController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();

            _tapeBackgroundController = CreateTapeBackground();
            _inputGameController = CreateInputGameController();
            _transportController = CreateTransportController();
            _abilitiesController = CreateAbilitiesController(placeForUI);

        }
        private TapeBackgroundController CreateTapeBackground()
        {
            //var tapeBackgroundController = new TapeBackgroundController(_leftMoveDiff, _rightMoveDiff);
            //AddController(tapeBackgroundController);

            return null;
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

        private AbilitiesController CreateAbilitiesController(Transform placeForUI)
        {
            var abilitiesController = new AbilitiesController(placeForUI, _transportController);
            AddController(abilitiesController);

            return abilitiesController;
        }
    }
}
