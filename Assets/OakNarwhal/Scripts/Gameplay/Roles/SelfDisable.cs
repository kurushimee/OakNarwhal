using UnityEngine;

public class SelfDisable : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
}