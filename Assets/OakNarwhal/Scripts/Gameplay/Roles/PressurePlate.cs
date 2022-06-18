using UnityEngine;
using UnityEngine.Events;

public class PressurePlate: MonoBehaviour
{
    public UnityEvent OnActivate;
    public UnityEvent OnDectivate;

    private int _contacts = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody)
        {
            _contacts++;
            if (_contacts <= 1)
            {
                OnActivate.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _contacts--;
        if(_contacts < 1)
        {
            OnDectivate.Invoke();
        }
    }
}
