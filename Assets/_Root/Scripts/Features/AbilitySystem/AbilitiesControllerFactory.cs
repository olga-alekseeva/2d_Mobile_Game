using Features.AbilitySystem.Abilities;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Features.AbilitySystem
{
    internal class AbilitiesControllerFactory:BaseController
    {
        private readonly ResourcePath _DataPath = new ResourcePath("Configs/Ability/AbilityItemConfigDataSource");
        private readonly ResourcePath _ViewPath = new ResourcePath("Prefabs/Ability/AbilitiesView");

        private readonly IAbilityActivator _abilityActivator;
        public AbilitiesControllerFactory(IAbilityActivator abilityActivator)=>
            _abilityActivator = abilityActivator;

        public AbilitiesController Create(Transform placeForUI)
        {
            AbilityItemConfig[] abilityItemConfigs = LoadItemConfigs();
            AbilitiesRepository repository = CreateRepository(abilityItemConfigs);
            AbilitiesView view = LoadView(placeForUI);

            var abilitiesController = 
                new AbilitiesController(view, repository, abilityItemConfigs, _abilityActivator);
            AddController(abilitiesController);

            return abilitiesController;
        }
        private AbilitiesView LoadView(Transform placeForUI)
        {
            var path = new ResourcePath("Prefabs/Ability/AbilitiesView");

            GameObject prefab = ResourcesLoader.LoadPrefab(path);
            GameObject objectView = UnityEngine.Object.Instantiate(prefab, placeForUI, false);
            AddGameObject(objectView);

            return objectView.GetComponent<AbilitiesView>();
        }
        private AbilityItemConfig[] LoadItemConfigs()
        {
            var path = new ResourcePath("Configs/Ability/AbilityItemConfigDataSource");
            return ContentDataSourceLoader.LoadAbilityItemConfigs(path);
        }


        private AbilitiesRepository CreateRepository(IEnumerable<IAbilityItem> abilityItemConfigs)
        {
            var repository = new AbilitiesRepository(abilityItemConfigs);
            AddRepository(repository);

            return repository;
        }
    }
}
