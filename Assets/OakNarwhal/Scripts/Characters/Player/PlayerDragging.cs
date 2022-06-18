using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDragging : MonoBehaviour
{
    [SerializeField] private float grabDistance = 1f;
    [SerializeField] private float dragForce = 1f;

    private SpringJoint2D _connection;

    public void HandleInput(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (_connection)
            Release();
        else
            TryToGrab();
    }

    private void TryToGrab()
    {
        var mTransform = transform;
        var hit = Physics2D.Raycast(mTransform.position, mTransform.up * grabDistance, 1f);
        if (hit && hit.rigidbody) Grab(hit.rigidbody);
    }

    private void Release()
    {
        if (_connection) Destroy(_connection);
    }

    private void Grab(Rigidbody2D body)
    {
        _connection = gameObject.AddComponent<SpringJoint2D>();
        _connection.connectedBody = body;
        _connection.frequency = dragForce;
    }
}