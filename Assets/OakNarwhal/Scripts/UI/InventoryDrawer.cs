using UnityEngine;

public class InventoryDrawer : MonoBehaviour
{
    [SerializeField] private ItemChooser _itemSlot = null;

    public void DisplayInventory()
    {
        int slotsCount = PlayerInventory.GetSlotsCount();
        
        ClearGrid();

        for(int i = 0; i < slotsCount; i++)
        {
            ItemChooser itemSlot = Instantiate(_itemSlot, transform);
            itemSlot.id = i;
            itemSlot.DrawItem();
        }
    }

    private void ClearGrid()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void Awake()
    {
        PlayerInventory.OnInventoryOpen += DisplayInventory;
    }
}
