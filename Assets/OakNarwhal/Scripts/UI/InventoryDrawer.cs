using UnityEngine;

public class InventoryDrawer : MonoBehaviour
{
    [SerializeField] private ItemChooser itemSlot;

    private void Awake()
    {
        PlayerInventory.OnInventoryOpen += DisplayInventory;
    }

    private void DisplayInventory()
    {
        var slotsCount = PlayerInventory.GetSlotsCount();

        ClearGrid();

        for (var i = 0; i < slotsCount; i++)
        {
            var newItemSlot = Instantiate(itemSlot, transform);
            newItemSlot.id = i;
            newItemSlot.DrawItem();
        }
    }

    private void ClearGrid()
    {
        foreach (Transform child in transform) Destroy(child.gameObject);
    }
}