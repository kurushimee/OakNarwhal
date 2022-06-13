using UnityEngine;

public struct InventoryItem
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name;
    [SerializeField] private string _description;

    public void SetItem(Item item)
    {
        _sprite = item.ItemSprite;
        _name = item.ItemName;
        _description = item.GetDescription();
    }

    public void Clear()
    {
        _sprite = null;
        _name = "";
        _description = "";
    }

    public bool IsEmpty()
    {
        bool isSpriteEmpty = false;
        bool isNameEmpty = false;
        bool isDescriptionEmpty = false;
        bool isEmpty = false;

        if (_sprite == null) isSpriteEmpty = true;
        if (_name == null || _name == "") isNameEmpty = true;
        if (_description == null || _description == "") isDescriptionEmpty = true;
        if (isSpriteEmpty && isNameEmpty && isDescriptionEmpty) isEmpty = true;

        return isEmpty;
    }
}
