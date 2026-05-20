using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAttack/Bullet")]
public class BulletAttack : EnemyAttackBase
{
    public GameObject bulletPrefab;
    public float speed;

    public override void ExecuteAttack(Transform enemy, Transform muzzle, Transform player)
    {
        Vector3 dir = (player.position - muzzle.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.Euler(0, 0, angle - 90f));

        if (bullet.TryGetComponent(out Rigidbody2D rb))
        {
            rb.linearVelocity = dir * speed;
        }
    }
}