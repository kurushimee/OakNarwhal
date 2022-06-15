using System;
using UnityEngine;

[Serializable]
public struct InventoryItem
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string name;
    [SerializeField] private string description;

    public Sprite GetSprite()
    {
        return sprite;
    }

    public string GetName()
    {
        return name;
    }

    public string GetDescription()
    {
        return description;
    }

    public void SetItem(InventoryItem item)
    {
        sprite = item.GetSprite();
        name = item.GetName();
        description = item.GetDescription();
    }

    public void Clear()
    {
        sprite = null;
        name = "";
        description = "";
    }

    public bool IsEmpty()
    {
        var isSpriteEmpty = false;
        var isNameEmpty = false;
        var isDescriptionEmpty = false;
        var isEmpty = false;

        if (sprite == null) isSpriteEmpty = true;
        if (string.IsNullOrEmpty(name)) isNameEmpty = true;
        if (string.IsNullOrEmpty(description)) isDescriptionEmpty = true;
        if (isSpriteEmpty && isNameEmpty && isDescriptionEmpty) isEmpty = true;

        return isEmpty;
    }
}