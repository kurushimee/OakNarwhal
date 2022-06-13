using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Movement
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        _rb.velocity = new Vector2(
            moveX * moveSpeed,
            moveY * moveSpeed
        );
    }
}