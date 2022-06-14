using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDrawer : MonoBehaviour
{
    [SerializeField] private Image _iconDisplay;
    [SerializeField] private TMP_Text _nameDisplay;
    [SerializeField] private TMP_Text _descriptionDisplay;

    private ItemDrawer()
    {
        PlayerInventory.OnHandItemChanged += DrawHandItem;
    }

    public void DrawHandItem()
    {
        InventoryItem item = PlayerInventory.GetItemInHand();
        DrawItem(item);
    }

    public void DrawItem(InventoryItem item)
    {
        _iconDisplay.sprite = item.GetSprite();
        _nameDisplay.text = item.GetName();
        _descriptionDisplay.text = item.GetDescription();
    }
}
