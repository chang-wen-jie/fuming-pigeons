using UnityEngine;
using TMPro;
using System;

public class ShotManager : MonoBehaviour
{
    public TMP_Text shotsText;
    public event Action OnAllShotsFired;
    public int maxShots = 10;

    private int shotsLeft;
    private int activeShots;
    
    private void Start()
    {
        shotsLeft = maxShots;
        activeShots = 0;
        UpdateShotsUI();
    }

    public int ShotsLeft => shotsLeft;
    public int ActiveShots => activeShots;

    public void UseShot()
    {
        if (shotsLeft <= 0) return;

        shotsLeft--;
        activeShots++;
        UpdateShotsUI();

        if (ShotsLeft <= 0) OnAllShotsFired?.Invoke();
    }

    public void RegisterShotLanded()
    {
        activeShots--;

        if (shotsLeft == 0 && activeShots == 0) OnAllShotsFired?.Invoke();
    }

    private void UpdateShotsUI()
    {
        if (shotsText == null) return;
        shotsText.text = "Munitie: " + shotsLeft;
    }
}
    