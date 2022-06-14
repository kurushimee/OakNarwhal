using UnityEngine;
using UnityEngine.Events;

public class ItemRequire : Interactable
{
    [SerializeField] private string[] _requiredItems;
    [SerializeField] private string _description;

    public UnityEvent OnStageChanged;
    public UnityEvent OnActivate;

    private int _stage = 0;
    private bool _unlocked = false;

    public override void Interact()
    {
        if (!_unlocked)
        {
            CheckStage();
            CheckAvalaible();
        }

        if(_unlocked)
        {
            OnActivate.Invoke();
        }
    }

    public override string GetDescription()
    {
        return _description;
    }

    private void CheckStage()
    {
        string requireItem = _requiredItems[_stage];
        if (requireItem == "" || PlayerInventory.GetItemInHand().GetName() == requireItem)
        {
            _stage++;
            OnStageChanged.Invoke();
            CheckAvalaible();
        }
    }

    private void CheckAvalaible()
    {
        if (_stage == _requiredItems.Length) _unlocked = true;
    }
}
