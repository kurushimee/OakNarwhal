using UnityEngine;
using UnityEngine.Events;

public class ItemRequire : Interactable
{
    [SerializeField] private string[] requiredItems;

    public UnityEvent onStageChanged;
    public UnityEvent onActivate;

    private int _stage;
    private bool _unlocked;

    public override void Interact()
    {
        if (!_unlocked)
        {
            CheckStage();
            CheckAvailable();
        }

        if (_unlocked) onActivate.Invoke();
    }

    private void CheckStage()
    {
        string requireItem = requiredItems[_stage];
        if (requireItem != "" && PlayerInventory.GetItemInHand().GetName() != requireItem) return;
        _stage++;
        onStageChanged.Invoke();
        CheckAvailable();
    }

    private void CheckAvailable()
    {
        if (_stage == requiredItems.Length) _unlocked = true;
    }
}