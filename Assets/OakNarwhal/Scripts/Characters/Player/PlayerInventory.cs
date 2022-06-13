using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _slotsCount = 0;
    [SerializeField] private static InventoryItem[] _inventorySlots = null;

    public static bool TryAddItemToInventory(Item item)
    {
        for(int i = 0; i < _inventorySlots.Length; i++)
        {
            InventoryItem slot = _inventorySlots[i];
            if (slot.IsEmpty())
            {
                slot.SetItem(item);
                _inventorySlots[i] = slot;
                return true;
            }
        }
        return false;
    }

    public static InventoryItem GetItemFromInventory(int slot)
    {
        return _inventorySlots[slot];
    }

    private void Awake()
    {
        _inventorySlots = new InventoryItem[_slotsCount];
    }
}