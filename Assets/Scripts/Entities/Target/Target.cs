using UnityEngine;

public class Target : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            TargetManager.Instance.TargetHit();
            Destroy(gameObject);
        }
    }
}
