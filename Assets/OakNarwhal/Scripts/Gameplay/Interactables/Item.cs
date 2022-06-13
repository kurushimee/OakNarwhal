using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Item : Interactable
{
    [SerializeField] private Sprite _sprite = null;
    [SerializeField] private string _description = "Description";
    [SerializeField] private InventoryItem _item;

    public override void Interact()
    {
        if (PlayerInventory.TryAddItemToInventory(this)) OnPickedUp();
    }

    public override string GetDescription()
    {
        return _description;
    }

    public InventoryItem GetItem()
    {
        return _item;
    }

    private void OnValidate()
    {
        UpdateItem();
    }

    private void UpdateItem()
    {
        GetComponent<SpriteRenderer>().sprite = _sprite;
    }

    private void OnPickedUp()
    {
        Destroy(gameObject);
    }
}