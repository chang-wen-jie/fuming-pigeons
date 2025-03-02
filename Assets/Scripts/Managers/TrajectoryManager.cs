using UnityEngine;
using System.Collections.Generic;

public class TrajectoryManager : MonoBehaviour
{
    public LineRenderer trajectoryLine;
    public int trajectoryPoints = 15;
    public float timeStep = 0.05f;

    private void Start()
    {
        trajectoryLine.positionCount = trajectoryPoints;
        trajectoryLine.startWidth = 0.05f;
        trajectoryLine.endWidth = 0.05f;
    }

    public void ShowTrajectory(Vector2 origin, Vector2 velocity)
    {
        Vector2 gravity = Physics2D.gravity;
        List<Vector2> points = new();

        Vector2 currentPosition = origin;
        Vector2 currentVelocity = velocity;

        for (int i = 0; i < trajectoryPoints; i++)
        {
            points.Add(currentPosition);
            currentVelocity += gravity * timeStep;
            currentPosition += currentVelocity * timeStep;
        }

        trajectoryLine.SetPositions(points.ConvertAll(p => (Vector3)p).ToArray());
        trajectoryLine.enabled = true;
    }

    public void HideTrajectory()
    {
        trajectoryLine.enabled = false;
    }
}
