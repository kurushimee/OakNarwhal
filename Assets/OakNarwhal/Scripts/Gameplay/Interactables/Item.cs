using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Item : Interactable
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string mName = "Item";
    [SerializeField] private string description = "Description";
    public Sprite ItemSprite => sprite;
    public string ItemName => mName;

    private void OnValidate()
    {
        UpdateItem();
    }

    public override void Interact()
    {
        if (PlayerInventory.TryAddItemToInventory(this)) OnPickedUp();
    }

    public override string GetDescription()
    {
        return description;
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