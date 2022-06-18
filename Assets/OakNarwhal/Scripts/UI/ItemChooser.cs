using UnityEngine;
using UnityEngine.UI;

public class ItemChooser : MonoBehaviour
{
    public int id;

    public void DrawItem()
    {
        var iconDisplay = transform.GetChild(0).GetComponent<Image>();
        iconDisplay.sprite = PlayerInventory.GetItemFromInventory(id).GetSprite();
    }

    public void GrabItem()
    {
        PlayerInventory.SetItemToHand(id);
    }
}