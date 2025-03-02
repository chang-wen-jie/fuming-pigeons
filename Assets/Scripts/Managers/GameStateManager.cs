using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private ShotManager shotManager;
    private TargetManager targetManager;
    private UIManager uiManager;

    private void Start()
    {
        shotManager = FindFirstObjectByType<ShotManager>();
        targetManager = FindFirstObjectByType<TargetManager>();
        uiManager = FindFirstObjectByType<UIManager>();
    }

    public void CheckGameState()
    {
        if (shotManager == null || targetManager == null || uiManager == null) return;

        if (targetManager.TargetsLeft <= 0) uiManager.ShowWinScreen();
        else if (shotManager.ShotsLeft <= 0 && shotManager.ActiveShots == 0) uiManager.ShowLoseScreen();
    }
}
