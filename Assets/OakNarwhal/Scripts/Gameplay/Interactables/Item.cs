using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Item : Interactable
{
    public Sprite ItemSprite { get { return _sprite; } }
    public string ItemName { get {return _name; } }


    [SerializeField] private Sprite _sprite = null;
    [SerializeField] private string _name = "Item";
    [SerializeField] private string _description = "Description";

    public override void Interact()
    {
        if(PlayerInventory.TryAddItemToInventory(this))
        {
            OnPickedUp();
        }
    }

    public override string GetDescription()
    {
        return _description;
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