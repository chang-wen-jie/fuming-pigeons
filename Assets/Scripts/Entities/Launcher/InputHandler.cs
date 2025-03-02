using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    public event Action<Vector2> OnDragStart;
    public event Action<Vector2> OnDragging;
    public event Action OnDragEnd;

    private Camera mainCamera;
    public Transform launchPoint;
    public float activationRadius;

    private bool isDragging = false;

    private void Start()
    {
        mainCamera = Camera.main;
        activationRadius = 1f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            
            if (Vector2.Distance(mousePosition, launchPoint.position) <= activationRadius)
            {
                isDragging = true;
                OnDragStart?.Invoke(mousePosition);
            }
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            OnDragging?.Invoke(mousePosition);
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            OnDragEnd?.Invoke();
        }
    }
}
