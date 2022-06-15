using UnityEngine;

public class Bomb : Interactable
{
    public bool isOn;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        UpdateBomb();
    }

    private void UpdateBomb()
    {
        _rb.gravityScale = isOn ? 1 : 0;
    }

    public override string GetDescription()
    {
        return isOn
            ? "Press [E] to turn <color=red>off</color> the bomb."
            : "Press [E] to turn <color=green>on</color> the bomb.";
    }

    public override void Interact()
    {
        isOn = !isOn;
        UpdateBomb();
    }
}