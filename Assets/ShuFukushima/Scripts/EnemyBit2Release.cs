using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "EnemyAttack/Bit2Release")]
public class EnemyBit2Release : EnemyAttackBase
{
    [SerializeField] private GameObject enemyBit2;
    //次の行動までのクールタイム
    [SerializeField] private float shotInterval = 0.05f;



    // ↓ここの関数の中に機能を作ってね
    public override IEnumerator ExecuteAttack(Transform enemy, Transform muzzle, Transform playerTransform)
    {
        if (enemyBit2 == null || muzzle == null || playerTransform == null)
        {
            yield break;
        }

        // ビットを生成
        GameObject chargeBullet = Instantiate(enemyBit2, muzzle.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity);


        yield return new WaitForSeconds(shotInterval);

    }
}