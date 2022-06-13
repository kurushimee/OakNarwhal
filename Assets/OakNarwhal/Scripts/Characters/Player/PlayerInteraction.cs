using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;
    public TextMeshProUGUI interactionText;
    public GameObject interactionHoldGo;  // The UI parent to disable when not interacting
    public Image interactionHoldProgress; // The progress bar for hold interaction type
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
        {
            if (hit.collider.TryGetComponent(out Interactable interactable))
            {
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                interactionHoldGo.SetActive(interactable.interactionType == Interactable.InteractionType.Hold);
                return;
            }
        }

        // If we miss, hide the UI
        interactionText.text = "";
        interactionHoldGo.SetActive(false);
    }

    private void HandleInteraction(Interactable interactable)
    {
        // Keybinding for interaction
        const KeyCode interactKey = KeyCode.E;
        
        switch (interactable.interactionType)
        {
            // Handle click interaction
            case Interactable.InteractionType.Click:
                if (Input.GetKeyDown(interactKey)) interactable.Interact();
                break;

            // Handle hold interaction
            case Interactable.InteractionType.Hold:
                if (Input.GetKey(interactKey))
                {
                    // If holding the interaction key, continue progress
                    interactable.IncreaseHoldTime();
                    if (interactable.GetHoldTime() > 1f)
                    {
                        // If held long enough, interact
                        interactable.Interact();
                        interactable.ResetHoldTime();
                        // Requires the player to stop holding the key before interacting again
                        return;
                    }
                }
                else
                {
                    // If stopped holding the interaction key, reset progress
                    interactable.ResetHoldTime();
                }

                interactionHoldProgress.fillAmount = interactable.GetHoldTime();
                break;

            // Throw an error if interaction type is incorrect
            default:
                throw new Exception("Unsupported type of interactable.");
        }
    }
}