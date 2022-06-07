using Features.AbilitySystem;
using Features.AbilitySystem.Abilities;
using Game.Cars.LowRiderClose;
using Game.Cars.RacingCar;
using Game.InputLogic;
using Game.TapeBackground;
using Game.Transport;
using Profile;
using Services;
using System;
using System.Collections.Generic;
using Tools;
using UnityEngine;

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
        private readonly IAbilitiesController _abilitiesController;
        public GameController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _leftMoveDiff = new SubscriptionProperty<float>();
            _rightMoveDiff = new SubscriptionProperty<float>();

            _tapeBackgroundController = CreateTapeBackground();
            _inputGameController = CreateInputGameController();
            _transportController = CreateTransportController();
            _abilitiesController = CreateAbilitiesController(placeForUI);

            ServiceRoster.Analytics.SendGameStarted();

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

        private IAbilitiesController CreateAbilitiesController(Transform placeForUI)
        {
            AbilityItemConfig[] abilityItemConfigs = LoadAbilityItemConfigs();
            AbilitiesRepository repository = CreateAbilitiesRepository(abilityItemConfigs);
            AbilitiesView view = LoadAbilitiesView(placeForUI);

            var abilitiesController = new AbilitiesController(view, repository, abilityItemConfigs, 
                _transportController);
            AddController(abilitiesController);

            return abilitiesController;
        }
        private AbilityItemConfig[] LoadAbilityItemConfigs()
        {
            var path = new ResourcePath("Configs/Ability/AbilityItemConfigDataSource");
            return ContentDataSourceLoader.LoadAbilityItemConfigs(path);
        }
        

        private AbilitiesRepository CreateAbilitiesRepository(IEnumerable<IAbilityItem> abilityItemConfigs)
        {
            var repository = new AbilitiesRepository(abilityItemConfigs);
            AddRepository(repository);

            return repository;
        }
        private AbilitiesView LoadAbilitiesView(Transform placeForUI)
        {
            var path = new ResourcePath("Prefabs/Ability/AbilitiesView");

            GameObject prefab = ResourcesLoader.LoadPrefab(path);
            GameObject objectView = UnityEngine.Object.Instantiate(prefab, placeForUI, false);
            AddGameObject(objectView);

            return objectView.GetComponent<AbilitiesView>();
        }
    }
}
