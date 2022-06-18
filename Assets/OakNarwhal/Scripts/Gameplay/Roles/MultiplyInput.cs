using UnityEngine;
using UnityEngine.Events;

public class MultiplyInput : MonoBehaviour
{
    public UnityEvent onActivate;
    public UnityEvent onDeactivate;

    [SerializeField] private int neededInputsCount = 1;

    private int _inputsCount;

    public void RegisterInput()
    {
        _inputsCount++;
        if (_inputsCount == neededInputsCount) onActivate.Invoke();
    }

    public void CancelInput()
    {
        _inputsCount--;
        if (_inputsCount == neededInputsCount) onDeactivate.Invoke();
    }
}