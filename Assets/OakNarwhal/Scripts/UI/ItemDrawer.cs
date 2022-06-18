using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDrawer : MonoBehaviour
{
    [SerializeField] private Image iconDisplay;
    [SerializeField] private TMP_Text nameDisplay;
    [SerializeField] private TMP_Text descriptionDisplay;

    private void Awake()
    {
        PlayerInventory.OnHandItemChanged += DrawHandItem;
    }

    private void DrawHandItem()
    {
        var item = PlayerInventory.GetItemInHand();
        DrawItem(item);
    }

    private void DrawItem(InventoryItem item)
    {
        iconDisplay.sprite = item.GetSprite();
        nameDisplay.text = item.GetName();
        descriptionDisplay.text = item.GetDescription();
    }
}