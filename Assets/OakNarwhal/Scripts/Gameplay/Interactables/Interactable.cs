using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        Click,
        Hold
    }

    public InteractionType interactionType;
    private float _holdTime;

    public abstract string GetDescription();
    public abstract void Interact();

    public void IncreaseHoldTime()
    {
        _holdTime += Time.deltaTime;
    }

    public void ResetHoldTime()
    {
        _holdTime = 0f;
    }

    public float GetHoldTime()
    {
        return _holdTime;
    }
}