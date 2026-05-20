using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAttack/Bullet")]
public class BulletAttack : EnemyAttackBase
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float speed = 5f;

    public override IEnumerator ExecuteAttack(Transform enemy, Transform muzzle, Transform player)
    {
        if (bulletPrefab == null)
        {
            Debug.LogWarning("BulletAttack: bulletPrefab Ç™ñ¢ê›íËÇ≈Ç∑");
            yield break;
        }

        if (muzzle == null)
        {
            Debug.LogWarning("BulletAttack: muzzle Ç™ null Ç≈Ç∑");
            yield break;
        }

        if (player == null)
        {
            Debug.LogWarning("BulletAttack: player Ç™ null Ç≈Ç∑");
            yield break;
        }

        Vector3 dir = (player.position - muzzle.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        GameObject bullet = Instantiate(
            bulletPrefab,
            muzzle.position,
            Quaternion.Euler(0f, 0f, angle - 90f)
        );

        if (bullet.TryGetComponent(out Rigidbody2D rb))
        {
            rb.linearVelocity = dir * speed;
        }
        else
        {
            Debug.LogWarning("BulletAttack: Bullet prefab Ç… Rigidbody2D Ç™ïtÇ¢ÇƒÇ¢Ç‹ÇπÇÒ");
        }

        yield break;
    }
}