using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decelerator : MonoBehaviour
{
    [SerializeField] private float _decelerationPercent = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInput input = collision.GetComponent<PlayerInput>();
        if (input)
        {
            input.SetSpeedMultiplier(_decelerationPercent);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerInput input = collision.GetComponent<PlayerInput>();
        if (input)
        {
            input.SetSpeedMultiplier(1f);
        }
    }
}
