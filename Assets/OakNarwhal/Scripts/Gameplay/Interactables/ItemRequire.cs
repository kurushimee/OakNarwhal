using UnityEngine;
using UnityEngine.Events;

public class ItemRequire : Interactable
{
    [SerializeField] private string _requiredItem;
    [SerializeField] private string _description;
    [SerializeField] bool _unlockedOnce = true;

    public UnityEvent OnActivate;

    private bool _unlocked = false;

    public override void Interact()
    {
        if(IsAvalaible())
        {
            OnActivate.Invoke();
        }
    }

    public override string GetDescription()
    {
        return _description;
    }

    private bool IsAvalaible()
    {
        if (_unlocked) return true;
        if (_requiredItem == "" || PlayerInventory.GetItemInHand().GetName() == _requiredItem)
        {
            if(_unlockedOnce)
            {
                _unlocked = true;
            }
            return true;
        }
        return false;
    }
}
