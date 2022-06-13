using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D _rb;
    private Animator _anim;
    private Vector2 _movement;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _anim.SetFloat(Horizontal, _movement.x);
        _anim.SetFloat(Vertical, _movement.y);
        _anim.SetFloat(Speed, _movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movement * moveSpeed;
    }
}