using UnityEngine;

public class WindManager : MonoBehaviour
{
    public static WindManager Instance;
    public ParticleSystem windParticles;
    public Vector2 windForce = new(2f, 0f);

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        if (windParticles != null) ApplyWindForce();
    }

    private void ApplyWindForce()
    {
        var _ = windParticles.velocityOverLifetime;
        _.enabled = true;
        _.x = windForce.x;
        _.y = windForce.y;
    }

    private void OnValidate() // Preview WindParticles in the ditor
    {
        if (windParticles != null) ApplyWindForce();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector3.zero, (Vector3)windForce * 5f);
    }

}
