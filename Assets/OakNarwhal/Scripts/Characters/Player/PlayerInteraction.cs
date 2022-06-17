using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance;
    [SerializeField] private Transform mTransform;

    private bool SearchInteractable(out Interactable interactable)
    {
        var hit = Physics2D.Raycast(mTransform.position, mTransform.up, interactionDistance);
        interactable = null;
        return hit && hit.collider.TryGetComponent(out interactable);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!SearchInteractable(out var interactable)) return;
        switch (interactable.interactionType)
        {
            // Handle click interaction
            case Interactable.InteractionType.Click:
                if (context.started) interactable.Interact();
                break;

            // Handle hold interaction
            case Interactable.InteractionType.Hold:
                if (context.performed)
                {
                    // If holding the interaction key, continue progress
                    interactable.IncreaseHoldTime();
                    if (interactable.GetHoldTime() >= 1f)
                    {
                        // If held long enough, interact
                        interactable.Interact();
                        interactable.ResetHoldTime();
                    }
                }
                else if (context.canceled)
                {
                    interactable.ResetHoldTime();
                }

                break;

            default:
                throw new Exception("Unsupported type of interactable.");
        }
    }
}