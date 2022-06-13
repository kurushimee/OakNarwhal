using UnityEngine;

public class UnlockableItem : MonoBehaviour
{
    public void Unlock()
    {
        gameObject.SetActive(true);
    }
}
