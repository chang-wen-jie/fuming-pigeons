using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.right);

        if (transform.position.x > 20f) transform.position = new Vector3(-20f, transform.position.y, transform.position.z);
    }
}
