using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            TargetManager.Instance.TargetHit();
            Destroy(gameObject);
        }
    }
}
