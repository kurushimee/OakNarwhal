using UnityEngine;
using UnityEngine.Events;
public class Pressing_plate : MonoBehaviour
{
    public UnityEvent OnActivate;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Rigidbody2D>())
        {
            OnActivate.Invoke();
            Debug.Log("PlatePressed");
        }
    }
}
