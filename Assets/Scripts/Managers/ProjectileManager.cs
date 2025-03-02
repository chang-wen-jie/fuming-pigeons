using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;

    private ShotManager shotManager;

    private void Start()
    {
        shotManager = FindFirstObjectByType<ShotManager>();
    }

    public void Shoot(Vector2 direction, float force)
    {
        GameObject newProjectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * force;

        if (newProjectile.TryGetComponent(out Projectile projectile)) projectile.OnProjectileLanded += shotManager.RegisterShotLanded; // Assign projectile to existing Projectile
    }
}
