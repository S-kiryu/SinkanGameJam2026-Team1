using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float ShootingInterval;
    public float ShootingTime = 0f;
    public float BulletSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShootingTime += Time.deltaTime;

        if (ShootingTime >= ShootingInterval)
        {
            Vector3 playerDir = (playerTransform.position - transform.position).normalized;

            float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;

            // 生成位置を取得
            Vector3 playerPos = transform.position;
            // 弾を生成
            GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.Euler(0, 0, angle - 90f));

            if (bullet.TryGetComponent(out Rigidbody2D rb2D))
            {
                Vector2 velocity = playerDir * BulletSpeed; // * Time.deltaTime;
                rb2D.linearVelocity = velocity;
            }

            ShootingTime = 0f;
        }

    }
}
