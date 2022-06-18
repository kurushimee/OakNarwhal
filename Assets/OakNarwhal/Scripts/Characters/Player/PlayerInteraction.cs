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
        if (context.performed) interactable.Interact();
    }
}