using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public float maxDragDistance = 2f;
    public float launchForceMultiplier = 5f;

    private ShotManager shotManager;
    private TargetManager targetManager;
    private TrajectoryManager trajectoryManager;
    private InputHandler inputHandler;
    private ProjectileManager projectileShooter;
    private GameStateManager gameStateManager;
    private Vector2 startPoint;
    private Vector2 endPoint;
    private bool canShoot;

    private void Start()
    {
        shotManager = FindFirstObjectByType<ShotManager>();
        targetManager = FindFirstObjectByType<TargetManager>(); 
        trajectoryManager = FindFirstObjectByType<TrajectoryManager>();
        inputHandler = FindFirstObjectByType<InputHandler>();
        projectileShooter = FindFirstObjectByType<ProjectileManager>();
        gameStateManager = FindFirstObjectByType<GameStateManager>();
        canShoot = true;

        if (inputHandler != null)
        {
            inputHandler.OnDragStart += HandleDragStart;
            inputHandler.OnDragging += HandleDragging;
            inputHandler.OnDragEnd += HandleDragEnd;
        }

        if (shotManager != null) shotManager.OnAllShotsFired += () => canShoot = false;
        if (targetManager != null) targetManager.OnAllTargetsDestroyed += () => canShoot = false;
    }

    private bool CanStartDrag()
    {
        if (shotManager == null || !canShoot || trajectoryManager == null || inputHandler == null || projectileShooter == null || gameStateManager == null) return false;
        return true;
    }

    private void HandleDragStart(Vector2 mousePosition)
    {
        if (!CanStartDrag()) return;

        float distance = Vector2.Distance(mousePosition, launchPoint.position);

        if (distance <= maxDragDistance)
        {
            startPoint = launchPoint.position;
            trajectoryManager.ShowTrajectory(startPoint, Vector2.zero);
        }
    }

    private void HandleDragging(Vector2 mousePosition)
    {
        if (!CanStartDrag()) return;

        Vector2 dragVector = startPoint - mousePosition;

        if (dragVector.magnitude > maxDragDistance)
            dragVector = dragVector.normalized * maxDragDistance;

        endPoint = startPoint - dragVector;

        Vector2 launchDirection = startPoint - endPoint;
        trajectoryManager.ShowTrajectory(launchPoint.position, launchDirection * launchForceMultiplier);
    }

    private void HandleDragEnd()
    {
        if (!CanStartDrag()) return;

        Vector2 launchDirection = startPoint - endPoint;
        float launchForce = launchDirection.magnitude * launchForceMultiplier;

        shotManager.UseShot();
        projectileShooter.Shoot(launchDirection.normalized, launchForce);
        trajectoryManager.HideTrajectory();
    }
}
