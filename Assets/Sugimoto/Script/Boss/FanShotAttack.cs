using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Attack/Fan Shot")]
public class FanShotAttack : EnemyAttackBase
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private int bulletCount = 3;
    [SerializeField] private float totalAngle = 60f;

    public override void ExecuteAttack(Transform enemy, Transform muzzle, Transform player)
    {
        if (bulletPrefab == null || muzzle == null || player == null) return;

        int count = Mathf.Max(1, bulletCount);

        Vector3 baseDir = (player.position - muzzle.position).normalized;
        float baseAngle = Mathf.Atan2(baseDir.y, baseDir.x) * Mathf.Rad2Deg;

        if (count == 1)
        {
            FireBullet(baseAngle, muzzle);
            return;
        }

        float angleStep = totalAngle / (count - 1);
        float startAngle = -totalAngle / 2f;

        // 中心から左右に等間隔で弾を発射
        for (int i = 0; i < count; i++)
        {
            float currentOffset = startAngle + angleStep * i;
            FireBullet(baseAngle + currentOffset, muzzle);
        }
    }

    // 指定された角度で弾を発射するメソッド
    private void FireBullet(float angle, Transform muzzle)
    {
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 dir = rotation * Vector2.up;
            rb.linearVelocity = dir * bulletSpeed;
        }
    }
}