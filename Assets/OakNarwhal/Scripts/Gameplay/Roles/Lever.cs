using UnityEngine.Events;

public class Lever : Interactable
{
    public UnityEvent onActivate;
    public UnityEvent onDeactivate;

    private bool _activated;

    public override void Interact()
    {
        _activated = !_activated;

        if (_activated)
            onActivate.Invoke();
        else
            onDeactivate.Invoke();
    }
}