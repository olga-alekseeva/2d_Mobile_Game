using Tools;
using System;
using UnityEngine;
using JetBrains.Annotations;
using Features.Inventory.Items;
using Object = UnityEngine.Object;

namespace Features.Inventory
{
    internal interface IInventoryController
    {
    }
    internal class InventoryController:BaseController, IInventoryController
    {
        private readonly IInventoryView _view;
        private readonly IInventoryModel _model;
        private readonly IItemsRepository _repository;

        public InventoryController(
            [NotNull] IInventoryView inventoryView,
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IItemsRepository itemsRepository)
        {
            _view
                 = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));

            _model
                = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));

            _repository
                = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));

            _view.Display(_repository.Items.Values, OnItemClicked);

            foreach (string itemId in _model.EquippedItems)
                _view.Select(itemId);
        }
        protected override void OnDispose()
        {
            _view.Clear();
            base.OnDispose();
        }

        private void OnItemClicked(string id)
        {
            bool equipped = _model.IsEquipped(id);

            if (equipped)
                UnequipItem(id);
            else
                EquipItem(id);
        }

        private void EquipItem(string id)
        {
            _view.Select(id);
            _model.EquipItem(id);
        }

        private void UnequipItem(string id)
        {
            _view.Unselect(id);
            _model.UnequipItem(id);
        }
    }

}

