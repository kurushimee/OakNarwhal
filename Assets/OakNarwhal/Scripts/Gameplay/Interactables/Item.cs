using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Item : Interactable
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string description = "Description";
    [SerializeField] private InventoryItem item;

    private void OnValidate()
    {
        UpdateItem();
    }

    public override void Interact()
    {
        if (PlayerInventory.TryAddItemToInventory(this)) OnPickedUp();
    }

    public InventoryItem GetItem()
    {
        return item;
    }

    private void UpdateItem()
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void OnPickedUp()
    {
        Destroy(gameObject);
    }
}