using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Door : MonoBehaviour
{
    [SerializeField] private Sprite open;
    [SerializeField] private Sprite closed;

    public void Open()
    {
        var mRenderer = gameObject.GetComponent<SpriteRenderer>();
        var mCollider = gameObject.GetComponent<Collider2D>();

        if (mRenderer) mRenderer.sprite = open;
        mCollider.enabled = false;
    }

    public void Close()
    {
        var mRenderer = gameObject.GetComponent<SpriteRenderer>();
        var mCollider = gameObject.GetComponent<Collider2D>();

        if (mRenderer) mRenderer.sprite = closed;
        mCollider.enabled = true;
    }
}