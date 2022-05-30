using Tools;
using System;
using UnityEngine;
using JetBrains.Annotations;
using Features.Inventory.Items;
using Object = UnityEngine.Object;

namespace Features.Inventory
{
    internal class InventoryController:BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Inventory/InventoryView");
        private readonly ResourcePath _configsPath = new ResourcePath("Configs/Inventory/ItemConfigDataSource");


        private readonly InventoryView _view;
        private readonly IInventoryModel _model;
        private readonly ItemsRepository _repository;

        public InventoryController(Transform placeForUI, IInventoryModel inventoryModel)
        {
            _model = inventoryModel;
            _repository = CreateRepository();
            _view = LoadView(placeForUI);

            _view.Display(_repository.Items.Values, OnItemClicked);

            foreach (string itemID in _model.EquippedItems)
                _view.Select(itemID);
        }

        private ItemsRepository CreateRepository()
        {
            ItemConfig[] itemConfigs = ContentDataSourceLoader.LoadItemConfigs(_configsPath);
            var repository = new ItemsRepository(itemConfigs);
            AddRepository(repository);

            return repository;
        }
        private InventoryView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi);
            AddGameObject(objectView);

            return objectView.GetComponent<InventoryView>();
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

