using UnityEngine.Events;

public class Lever : Interactable
{
    public UnityEvent OnActivate;
    public UnityEvent OnDectivate;

    private bool _activated = false;

    public override void Interact()
    {
        _activated = !_activated;

        if(_activated)
        {
            OnActivate.Invoke();
        }
        else
        {
            OnDectivate.Invoke();
        }
    }
}
