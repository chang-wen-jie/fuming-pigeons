using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private ShotManager shotManager;
    private TargetManager targetManager;
    private GameStateManager gameStateManager;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        shotManager = FindFirstObjectByType<ShotManager>();
        targetManager = FindFirstObjectByType<TargetManager>();
        gameStateManager = FindFirstObjectByType<GameStateManager>();

        if (shotManager != null) shotManager.OnAllShotsFired += CheckIfGameShouldEnd;
        if (targetManager != null) targetManager.OnAllTargetsDestroyed += HandleAllTargetsDestroyed;
    }

    public void CheckIfGameShouldEnd()
    {
        if (shotManager.ShotsLeft == 0 && shotManager.ActiveShots == 0) gameStateManager.CheckGameState();
    }

    private void HandleAllTargetsDestroyed()
    {
        gameStateManager.CheckGameState();
    }
}
