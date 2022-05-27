using UnityEngine.Events;

namespace Features.Inventory.Items
{
    internal interface IItemView
    {
        void Init(IItem item, UnityAction clickAction);
        void Deinit();
        void Select();
        void Unselect();
    }
}