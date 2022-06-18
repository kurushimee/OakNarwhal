using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public UnityEvent onActivate;
    public UnityEvent onDeactivate;

    private int _contacts;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.attachedRigidbody) return;
        _contacts++;
        if (_contacts <= 1) onActivate.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _contacts--;
        if (_contacts < 1) onDeactivate.Invoke();
    }
}