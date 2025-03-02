using UnityEngine;
using TMPro;
using System;

public class TargetManager : MonoBehaviour
{
    public static TargetManager Instance { get; private set; }
    public TMP_Text targetText;
    public event Action OnAllTargetsDestroyed;

    private int targetsLeft;

    private void Awake()
    {
        if (Instance == null) Instance = this;  
        else Destroy(gameObject);
    }

    private void Start()
    {
        targetsLeft = targetsLeft = FindObjectsByType<Target>(FindObjectsSortMode.None).Length;
        UpdateTargetText();
    }

    public int TargetsLeft => targetsLeft;

    public void TargetHit()
    {
        targetsLeft--;
        UpdateTargetText();

        if (TargetsLeft <= 0) OnAllTargetsDestroyed?.Invoke();
    }

    private void UpdateTargetText()
    {
        if (targetText == null) return;

        targetText.text = "Doelwit: " + targetsLeft;
    }
}
