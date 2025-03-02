using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public event Action OnProjectileLanded;

    private Rigidbody2D rb;
    private bool hasLanded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hasLanded = false;
    }

    private void FixedUpdate()
    {
        if (WindManager.Instance != null) rb.AddForce(WindManager.Instance.windForce * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasLanded) return; // Prevent multiple OnProjectileLanded triggers when colliding with another Projectile
        hasLanded = true;

        if (!collision.gameObject.CompareTag("Projectile"))
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearVelocity = Vector2.zero;

            transform.SetParent(collision.transform);

        } else Destroy(collision.gameObject);

        OnProjectileLanded?.Invoke();
    }
}
