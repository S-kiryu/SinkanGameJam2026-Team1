using UnityEngine;

public class EnemyMissileShooting : MonoBehaviour
{
    public float ShootingInterval;
    public float ShootingTime = 5f;
    public float MissileSpeed;
    [SerializeField] private GameObject MissilePrefab;
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
            Missile();
        }

    }

    void Missile()
    {
        Vector3 playerDir = (playerTransform.position - muzzle.transform.position).normalized;

        float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;

        // 生成位置を取得
        Vector3 playerPos = transform.position;
        // 弾を生成
        GameObject missile = Instantiate(MissilePrefab, muzzle.position, Quaternion.Euler(0, 0, angle - 90f));

        if (missile.TryGetComponent(out Rigidbody2D rb2D))
        {
            Vector2 velocity = playerDir * MissileSpeed; // * Time.deltaTime;
            rb2D.linearVelocity = velocity;
        }

        ShootingTime = 0f;
    }
}
