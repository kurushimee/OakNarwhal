using UnityEngine;

public class MultiplyInput : MonoBehaviour
{
    [SerializeField] private int requiredTriggers;
    private int _turnedOn;
    public void Increment()
    {
        Check(++_turnedOn);
    }
    public void Decrement()
    {
        Check(--_turnedOn);
    }
    private void Check(int x)
    {
        GetComponent<Collider2D>().enabled = x >= requiredTriggers;
    }
}
