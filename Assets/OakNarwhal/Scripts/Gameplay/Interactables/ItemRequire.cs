using UnityEngine;
using UnityEngine.Events;

public class ItemRequire : Interactable
{
    [SerializeField] private string _requiredItem;
    [SerializeField] private string _description;

    public UnityEvent OnActivate;

    public override void Interact()
    {
        if (PlayerInventory.GetItemInHand().GetName() == _requiredItem)
        {
            OnActivate.Invoke();
        }
    }

    public override string GetDescription()
    {
        return _description;
    }
}
