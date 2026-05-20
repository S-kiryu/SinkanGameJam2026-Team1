using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Attack/Straight Shot")]
public class StraightShotAttack : EnemyAttackBase
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10f;

    public override void ExecuteAttack(Transform enemy, Transform muzzle, Transform player)
    {
        if (bulletPrefab == null || muzzle == null || player == null) return;

        Vector3 dir = (player.position - muzzle.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = dir * bulletSpeed;
        }
    }
}