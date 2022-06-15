using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");
    public float moveSpeed;
    private Animator _anim;
    private Vector2 _movement;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _anim.SetFloat(Horizontal, _movement.x);
        _anim.SetFloat(Vertical, _movement.y);
        _anim.SetFloat(Speed, _movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movement * moveSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }
}