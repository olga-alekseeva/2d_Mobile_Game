using Features.Inventory.Items;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Features.Inventory
{


    internal class InventoryFactory : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Inventory/InventoryView");
        private readonly ResourcePath _dataSourcePath = new ResourcePath("Configs/Inventory/ItemConfigDataSource");
        private readonly IInventoryModel _model;
        public InventoryFactory(IInventoryModel model) =>
            _model = model;
        public InventoryController Create(Transform placeForUI)
        {
            InventoryView view = LoadView(placeForUI);
            ItemsRepository repository = CreateRepository();
            var inventoryController = new InventoryController(view, _model, repository);
            AddController(inventoryController);


            return inventoryController;
        }
        private InventoryView LoadView(Transform placeForUI)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab, placeForUI);
            AddGameObject(objectView);

            return objectView.GetComponent<InventoryView>();
        }
        private ItemsRepository CreateRepository()
        {
            ItemConfig[] itemConfigs = LoadCionfigs(_dataSourcePath);
            var repository = new ItemsRepository(itemConfigs);
            AddRepository(repository);

            return repository;
        }

        private static ItemConfig[] LoadCionfigs(ResourcePath path)
        => ContentDataSourceLoader.LoadItemConfigs(path);
    }
}

       