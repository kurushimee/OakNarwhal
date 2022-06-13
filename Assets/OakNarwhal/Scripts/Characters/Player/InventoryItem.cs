using UnityEngine;

[System.Serializable]
public struct InventoryItem
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name;
    [SerializeField] private string _description;

    public Sprite GetSprite()
    {
        return _sprite;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetItem(InventoryItem item)
    {
        _sprite = item.GetSprite();
        _name = item.GetName();
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