using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    private static InventoryItem[] _inventorySlots;
    private static InventoryItem _itemInHand;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private int slotsCount;

    private bool _inventoryOpen;

    private void Awake()
    {
        _inventorySlots = new InventoryItem[slotsCount];
    }

    public static event Action OnInventoryOpen;
    public static event Action OnHandItemChanged;

    public static bool TryAddItemToInventory(Item item)
    {
        for (var i = 0; i < _inventorySlots.Length; i++)
        {
            var slot = _inventorySlots[i];

            if (!slot.IsEmpty()) continue;

            slot.SetItem(item.GetItem());
            _inventorySlots[i] = slot;
            SetItemToHand(0); //to remove
            return true;
        }

        return false;
    }

    public static InventoryItem GetItemInHand()
    {
        return _itemInHand;
    }

    public static void SetItemToHand(int id)
    {
        _itemInHand = GetItemFromInventory(id);
        OnHandItemChanged?.Invoke();
    }

    public static InventoryItem GetItemFromInventory(int slot)
    {
        return _inventorySlots[slot];
    }

    public static int GetSlotsCount()
    {
        return _inventorySlots.Length;
    }

    public void ActivateInventory(InputAction.CallbackContext context)
    {
        if (!_inventoryOpen) OnInventoryOpen?.Invoke();
        inventoryUI.SetActive(!_inventoryOpen);
        _inventoryOpen = !_inventoryOpen;
    }
}