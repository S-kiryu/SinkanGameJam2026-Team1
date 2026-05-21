using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAttack/MissileShot")]
public class EnemyMissileShot : EnemyAttackBase
{
    [SerializeField] private GameObject missilePrefab;
    //次の行動までのクールタイム
    [SerializeField] private float shotInterval = 0.05f;
    [SerializeField] private float missileSpeed = 3f;


    // ↓ここの関数の中に機能を作ってね
    public override IEnumerator ExecuteAttack(Transform enemy, Transform muzzle, Transform playerTransform)
    {
        if (missilePrefab == null || muzzle == null || playerTransform == null)
        {
            yield break;
        }

        Vector3 playerDir = (playerTransform.position - muzzle.transform.position).normalized;

        float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;

        // 生成位置を取得
        Vector3 playerPos = muzzle.transform.position;
        // 弾を生成
        GameObject missile = Instantiate(missilePrefab, muzzle.position, Quaternion.Euler(0, 0, angle - 90f));

        Destroy(missile, 5f);

        if (missile.TryGetComponent(out Rigidbody2D rb2D))
        {
            Vector2 velocity = playerDir * missileSpeed;
            rb2D.linearVelocity = velocity;
        }

        yield return new WaitForSeconds(shotInterval);

    }
}