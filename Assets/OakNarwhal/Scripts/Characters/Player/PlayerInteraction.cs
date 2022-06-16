using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance;
    [SerializeField] private TextMeshProUGUI interactionText;
    [SerializeField] private GameObject interactionHoldGo; // The UI parent to disable when not interacting
    [SerializeField] private Image interactionHoldProgress; // The progress bar for hold interaction type
    [SerializeField] private Transform mTransform;

    private void Update()
    {
        // If we hit, display interaction text
        if (SearchInteractable(out var interactable))
        {
            interactionText.text = interactable.GetDescription();
            interactionHoldGo.SetActive(interactable.interactionType == Interactable.InteractionType.Hold);
            return;
        }

        // If we miss, hide the UI
        interactionText.text = "";
        interactionHoldGo.SetActive(false);
    }

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

                interactionHoldProgress.fillAmount = interactable.GetHoldTime();
                break;

            default:
                throw new Exception("Unsupported type of interactable.");
        }
    }
}