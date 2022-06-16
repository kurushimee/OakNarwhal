using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private const float MoveSpeed = 5f;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");
    private Animator _anim;
    private Vector3 _lastMoveDir;
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
        _rb.velocity = _movement * MoveSpeed;
        _lastMoveDir = _movement.normalized;
    }

    private bool CanMove(Vector3 dir, float distance)
    {
        return Physics2D.Raycast(transform.position + dir, dir, distance).collider == null;
    }

    private void TryMove(Vector3 baseMoveDir, float distance)
    {
        var moveDir = baseMoveDir;
        var canMove = CanMove(moveDir, distance);

        if (!canMove)
        {
            // Cannot move diagonally
            moveDir = new Vector3(baseMoveDir.x, 0f).normalized;
            canMove = moveDir.x != 0f && CanMove(moveDir, distance);
            if (!canMove)
            {
                // Cannot move horizontally
                moveDir = new Vector3(0f, baseMoveDir.y).normalized;
                canMove = moveDir.y != 0f && CanMove(moveDir, distance);
            }
        }

        if (!canMove) return;
        _lastMoveDir = moveDir;
        transform.position += moveDir * distance;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        const float dashDistance = 3f;
        TryMove(_lastMoveDir, dashDistance);
    }
}