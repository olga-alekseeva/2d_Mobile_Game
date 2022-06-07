using System;
using UnityEngine;
using JetBrains.Annotations;
using Features.AbilitySystem.Abilities;
using Tools;
using System.Collections.Generic;

namespace Features.AbilitySystem
{
    internal interface IAbilitiesController
    { }

    internal class AbilitiesController : BaseController
    {
        private readonly IAbilitiesView _view;
        private readonly IAbilitiesRepository _repository;
        private readonly IAbilityActivator _abilityActivator;


        public AbilitiesController(
            [NotNull] IAbilitiesView abilitiesView,
            [NotNull] IAbilitiesRepository abilitiesRepository,
            [NotNull] IEnumerable<IAbilityItem> abilityItems,
            [NotNull] IAbilityActivator abilityActivator)
        {
            _view
               = abilitiesView ?? throw new ArgumentNullException(nameof(abilitiesView));

            _repository
                = abilitiesRepository ?? throw new ArgumentNullException(nameof(abilitiesRepository));

            _abilityActivator
                = abilityActivator ?? throw new ArgumentNullException(nameof(abilityActivator));

            if (abilityItems == null)
                throw new ArgumentNullException(nameof(abilityItems));

            _view.Display(abilityItems, OnAbilityViewClicked);
        }

        protected override void OnDispose()
        {
            _view.Clear();
            base.OnDispose();
        }

        private void OnAbilityViewClicked(string abilityId)
        {
            if (_repository.Items.TryGetValue(abilityId, out IAbility ability))
                ability.Apply(_abilityActivator);
        }
    }
}
