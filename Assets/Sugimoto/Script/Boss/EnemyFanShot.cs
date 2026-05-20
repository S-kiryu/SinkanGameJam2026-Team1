using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAttack/FanShot")]
public class EnemyFanShot : EnemyAttackBase
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int shotCount = 20;
    [SerializeField] private float shotInterval = 0.05f;
    [SerializeField] private float totalAngle = 120f;
    [SerializeField] private float bulletSpeed = 8f;

    public override IEnumerator ExecuteAttack(Transform enemy, Transform muzzle, Transform playerTransform)
    {
        if (bulletPrefab == null || muzzle == null || playerTransform == null)
        {
            yield break;
        }

        Vector2 baseDir = (playerTransform.position - muzzle.position).normalized;
        float baseAngle = Mathf.Atan2(baseDir.y, baseDir.x) * Mathf.Rad2Deg - 90f;

        for (int i = 0; i < shotCount; i++)
        {
            float t = shotCount <= 1 ? 0.5f : (float)i / (shotCount - 1);
            float offsetAngle = Mathf.Lerp(-totalAngle * 0.5f, totalAngle * 0.5f, t);

            Quaternion rot = Quaternion.Euler(0f, 0f, baseAngle + offsetAngle);
            GameObject bullet = Instantiate(bulletPrefab, muzzle.position, rot);

            if (bullet.TryGetComponent(out Rigidbody2D rb))
            {
                rb.linearVelocity = bullet.transform.up * bulletSpeed;
            }

            yield return new WaitForSeconds(shotInterval);
        }
    }
}