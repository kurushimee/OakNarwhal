using UnityEngine;
using UnityEngine.Events;

public class MultiplyInput : MonoBehaviour
{
    public UnityEvent OnActivate;
    public UnityEvent OnDectivate;

    [SerializeField] private int _neededInputsCount = 1;

    private int _inputsCount = 0;

    public void RegisterInput()
    {
        _inputsCount++;
        if (_inputsCount == _neededInputsCount)
        {
            OnActivate.Invoke();
        }
    }

    public void CancelInput()
    {
        _inputsCount--;
        if (_inputsCount == _neededInputsCount)
        {
            OnDectivate.Invoke();
        }
    }
}
