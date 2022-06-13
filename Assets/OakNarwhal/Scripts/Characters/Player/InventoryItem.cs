using UnityEngine;

public struct InventoryItem
{
    private Sprite _sprite;
    private string _name;
    private string _description;

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
        var isSpriteEmpty = false;
        var isNameEmpty = false;
        var isDescriptionEmpty = false;
        var isEmpty = false;

        if (_sprite == null) isSpriteEmpty = true;
        if (string.IsNullOrEmpty(_name)) isNameEmpty = true;
        if (string.IsNullOrEmpty(_description)) isDescriptionEmpty = true;
        if (isSpriteEmpty && isNameEmpty && isDescriptionEmpty) isEmpty = true;

        return isEmpty;
    }
}