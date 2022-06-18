using UnityEngine;

public class Decelerator : MonoBehaviour
{
    [SerializeField] private float decelerationPercent = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var input = collision.GetComponent<PlayerInput>();
        if (input) input.SetSpeedMultiplier(decelerationPercent);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var input = collision.GetComponent<PlayerInput>();
        if (input) input.SetSpeedMultiplier(1f);
    }
}