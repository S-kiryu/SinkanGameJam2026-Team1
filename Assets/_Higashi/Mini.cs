using UnityEngine;

public class OrbitObject : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform enemyTransform;

    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform muzzle;

    [SerializeField] private float shootingInterval = 0.3f;
    [SerializeField] private float bulletSpeed = 5;

    private float timer = 0f;

    public float radius = 2f;
    public float speed = 5f;

    private float currentAngle = 0f;

    void Update()
    {
        ShootMini();
        RotatoMini();
    }

    void ShootMini()
    {
        timer = Time.time;

        if (timer >= shootingInterval)
        {
            Vector3 playerDir = (enemyTransform.position - transform.position).normalized;

            float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;

            GameObject bullet = Instantiate(Bullet,muzzle.position,Quaternion.Euler(0, 0, angle - 90f));

            if (bullet.TryGetComponent(out Rigidbody2D rb2D))
            {
                Vector2 velocity = playerDir * bulletSpeed * Time.deltaTime;
                rb2D.linearVelocity = velocity;
            }
        }
    }

    void RotatoMini()
    {
        currentAngle += speed * Time.deltaTime;

        if (currentAngle > Mathf.PI * 2f)
        {
            currentAngle -= Mathf.PI * 2f;
        }

        float x = Mathf.Cos(currentAngle) * radius;
        float y = Mathf.Sin(currentAngle) * radius;

        Vector3 newPosition = playerTransform.position + new Vector3(x, y, 0f);
        transform.position = newPosition;

        float angleDegrees = currentAngle * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees - 90f);
    }
}