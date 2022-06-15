using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;
    public TextMeshProUGUI interactionText;
    public GameObject interactionHoldGo; // The UI parent to disable when not interacting
    public Image interactionHoldProgress; // The progress bar for hold interaction type
    private Interactable _interactable;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        var hit = Physics2D.Raycast(_transform.position - new Vector3(0, -0.6f, 0), _transform.up, interactionDistance);

        // If we hit, display interaction text
        if (hit)
            if (hit.collider.TryGetComponent(out Interactable interactable))
            {
                interactionText.text = interactable.GetDescription();
                interactionHoldGo.SetActive(interactable.interactionType == Interactable.InteractionType.Hold);
                _interactable = interactable;
                return;
            }

        // If we miss, hide the UI
        interactionText.text = "";
        interactionHoldGo.SetActive(false);
    }

    public void HandleInteraction(InputAction.CallbackContext context)
    {
        switch (_interactable.interactionType)
        {
            // Handle click interaction
            case Interactable.InteractionType.Click:
                if (context.performed) _interactable.Interact();
                break;

            // Handle hold interaction
            case Interactable.InteractionType.Hold:
                if (context.performed)
                {
                    // If holding the interaction key, continue progress
                    _interactable.IncreaseHoldTime();
                    if (_interactable.GetHoldTime() > 1f)
                    {
                        // If held long enough, interact
                        _interactable.Interact();
                        _interactable.ResetHoldTime();
                        // Requires the player to stop holding the key before interacting again
                        return;
                    }
                }
                else
                {
                    // If stopped holding the interaction key, reset progress
                    _interactable.ResetHoldTime();
                }

                interactionHoldProgress.fillAmount = _interactable.GetHoldTime();
                break;

            // Throw an error if interaction type is incorrect
            default:
                throw new Exception("Unsupported type of interactable.");
        }
    }
}