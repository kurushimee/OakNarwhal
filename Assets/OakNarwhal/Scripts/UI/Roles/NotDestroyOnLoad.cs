using UnityEngine;

public class NotDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}