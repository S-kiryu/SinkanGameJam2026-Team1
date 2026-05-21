using UnityEngine;

public class HorizontalPatrolMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float leftLimit = -5f;
    [SerializeField] private float rightLimit = 5f;

    private int direction = 1;

    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private void CheckBounds()
    {
        if (transform.position.x >= rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.x <= leftLimit)
        {
            direction = 1;
        }
    }
}