using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAttack/Bullet")]
public class BulletAttack : EnemyAttackBase
{
    public GameObject bulletPrefab;
    public float speed = 5f;

    public override void ExecuteAttack(Transform enemy, Transform muzzle, Transform player)
    {
        if (bulletPrefab == null)
        {
            Debug.LogWarning("BulletAttack: bulletPrefab ‚ª–¢Ý’è‚Å‚·");
            return;
        }

        if (muzzle == null)
        {
            Debug.LogWarning("BulletAttack: muzzle ‚ª null ‚Å‚·");
            return;
        }

        if (player == null)
        {
            Debug.LogWarning("BulletAttack: player ‚ª null ‚Å‚·");
            return;
        }

        Vector3 dir = (player.position - muzzle.position).normalized;
        Debug.Log($"BulletAttack: ”­ŽË•ûŒü dir={dir}, speed={speed}");

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(
            bulletPrefab,
            muzzle.position,
            Quaternion.Euler(0, 0, angle - 90f)
        );

        Debug.Log($"BulletAttack: ’e¶¬¬Œ÷ -> {bullet.name}");

        if (bullet.TryGetComponent(out Rigidbody2D rb))
        {
            rb.linearVelocity = dir * speed;
            Debug.Log($"BulletAttack: velocity Ý’è -> {rb.linearVelocity}");
        }
        else
        {
            Debug.LogWarning("BulletAttack: Bullet prefab ‚É Rigidbody2D ‚ª•t‚¢‚Ä‚¢‚Ü‚¹‚ñ");
        }
    }
}