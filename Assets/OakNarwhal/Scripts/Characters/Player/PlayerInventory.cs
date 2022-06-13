using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private static InventoryItem[] _inventorySlots;
    [SerializeField] private int slotsCount;

    private void Awake()
    {
        _inventorySlots = new InventoryItem[slotsCount];
    }

    public static bool TryAddItemToInventory(Item item)
    {
        for (var i = 0; i < _inventorySlots.Length; i++)
        {
            var slot = _inventorySlots[i];

            if (!slot.IsEmpty()) continue;

            slot.SetItem(item);
            _inventorySlots[i] = slot;
            return true;
        }

        return false;
    }

    public static InventoryItem GetItemFromInventory(int slot)
    {
        return _inventorySlots[slot];
    }
}