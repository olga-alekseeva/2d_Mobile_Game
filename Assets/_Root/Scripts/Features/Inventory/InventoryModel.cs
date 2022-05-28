using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Features.Inventory
{
    internal interface IInventoryModel
    {
        IReadOnlyList<string> EquippedItems { get; }
        void EquipItem(string item);    
        void UnequipItem(string item);
        bool isEquipped(string item);    
    }
    internal class InventoryModel : IInventoryModel
    {
        private readonly List<string> _equippedItems = new();
        public IReadOnlyList<string> EquippedItems => _equippedItems;

        public void EquipItem(string item)
        {
            if(!isEquipped(item))
                _equippedItems.Add(item);   
        }

        public bool isEquiped(string item)
        {
            throw new System.NotImplementedException();
        }

        public void UnequipItem(string item)
        {
            throw new System.NotImplementedException();
        }
    }
}