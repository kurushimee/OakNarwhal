using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    private static InventoryItem[] _inventorySlots;
    private static InventoryItem _itemInHand;
    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private int _slotsCount;

    public static event Action OnInventoryOpen;
    public static event Action OnHandItemChanged;

    private bool _inventoryOpen = false;

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
        OnHandItemChanged.Invoke();
    }

    public static InventoryItem GetItemFromInventory(int slot)
    {
        return _inventorySlots[slot];
    }

    public static int GetSlotsCount()
    {
        return _inventorySlots.Length;
    }

    private void Awake()
    {
        _inventorySlots = new InventoryItem[_slotsCount];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ActivateInventory();
        }
    }

    private void ActivateInventory()
    {
        if (_inventoryOpen)
        {
            _inventoryUI.SetActive(false);
            _inventoryOpen = false;
        }
        else
        {
            OnInventoryOpen.Invoke();
            _inventoryUI.SetActive(true);
            _inventoryOpen = true;
        }
    }
}