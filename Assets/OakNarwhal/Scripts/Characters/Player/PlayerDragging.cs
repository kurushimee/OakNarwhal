using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDragging : MonoBehaviour
{
    [SerializeField] private float _grabDistance = 1f;
    [SerializeField] private float _dragForce = 1f;

    private SpringJoint2D _connection = null;

    public void HandleInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_connection)
            {
                Release();
            }
            else
            {
                TryToGrab();
            }
        }
    }

    private void TryToGrab()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up * _grabDistance, 1f);
        if (hit && hit.rigidbody)
        {
            Grab(hit.rigidbody);
        }
    }

    public void Release()
    {
        if(_connection)
        {
            Destroy(_connection);
        }
    }

    private void Grab(Rigidbody2D body)
    {
        _connection = gameObject.AddComponent<SpringJoint2D>();
        _connection.connectedBody = body;
        _connection.frequency = _dragForce;
    }
}
