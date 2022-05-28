using System;
using System.Linq;
using Features.Inventory.Items;


namespace Tools
{
    internal class ContentDataSourceLoader
    {
        public static ItemConfig[] LoadItemConfigs(ResourcePath path)
        {
            var dataSource = ResourcesLoader.LoadObject<ItemConfigDataSource>(path);
            return dataSource == null ? Array.Empty<ItemConfig>() : dataSource.ItemConfigs.ToArray();
        }
    }
}
