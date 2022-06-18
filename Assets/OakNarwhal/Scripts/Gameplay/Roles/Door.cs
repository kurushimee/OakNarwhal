using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Door : MonoBehaviour
{
    [SerializeField] private Sprite _open = null;
    [SerializeField] private Sprite _closed = null;

    public void Open()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        Collider2D collider = gameObject.GetComponent<Collider2D>();

        if(renderer)
        {
            renderer.sprite = _open;
        }
        collider.enabled = false;
    }

    public void Close()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        Collider2D collider = gameObject.GetComponent<Collider2D>();

        if (renderer)
        {
            renderer.sprite = _closed;
        }
        collider.enabled = true;
    }
}
