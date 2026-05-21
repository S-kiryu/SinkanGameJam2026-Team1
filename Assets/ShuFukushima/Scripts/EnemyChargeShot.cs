using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "EnemyAttack/ChargeShot")]
public class EnemyChargeShot : EnemyAttackBase
{
    [SerializeField] private GameObject chargeBulletPrefab;
    //次の行動までのクールタイム
    [SerializeField] private float shotInterval = 0.05f;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private int chargeTime = 5;
    [SerializeField] private float nowTime = 0f;
    [SerializeField] private int waitTime = 1;
    [SerializeField] private EnemyChargeBullet chargeBulletScript;


    // ↓ここの関数の中に機能を作ってね
    public override IEnumerator ExecuteAttack(Transform enemy, Transform muzzle, Transform playerTransform)
    {
        if (chargeBulletPrefab == null || muzzle == null || playerTransform == null)
        {
            yield break;
        }

        // 弾本体を生成
        // 弾を生成
        GameObject chargeBullet = Instantiate(chargeBulletPrefab, muzzle.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity);

        // 弾のスクリプトを取得
        chargeBulletScript = chargeBullet.GetComponent<EnemyChargeBullet>();
        // 弾をチャージする時間を伝える
        chargeBulletScript.chargeTime = chargeTime + 1;



        // 弾を大きくする処理
        for(int i = 0; i <= chargeTime; i++)
        {
            // 指定秒数だけ弾を大きくする（待機）

            yield return new WaitForSeconds(waitTime);
        }


        // 弾を発射する処理
        if(chargeBullet != null)
        {
            // 弾の角度をプレイヤーに合わせる
            Vector3 playerDir = (playerTransform.position - chargeBullet.transform.position).normalized;

            float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;

            Destroy(chargeBullet, 5f);

            if (chargeBullet.TryGetComponent(out Rigidbody2D rb2D))
            {
                Vector2 velocity = playerDir * bulletSpeed;
                rb2D.linearVelocity = velocity;
            }
        }



        yield return new WaitForSeconds(shotInterval);

    }
}
