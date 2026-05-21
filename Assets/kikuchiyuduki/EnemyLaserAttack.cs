using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAttack/LaserAttack")]
public class EnemyLaserAttack : EnemyAttackBase
{
    [Header("オブジェクト")]
    [SerializeField] private GameObject warningLinePrefab;
    [SerializeField] private GameObject laserPrefab;

    [Header("時間")]
    [SerializeField] private float warningTime = 1f;
    [SerializeField] private float laserDuration = 0.5f;

    [Header("次の攻撃まで")]
    [SerializeField] private float shotInterval = 3f;

    [Header("レーザー本数")]
    [SerializeField] private int minLaserCount = 1;
    [SerializeField] private int maxLaserCount = 5;

    [Header("ランダム位置")]
    [SerializeField] private float minX = -7f;
    [SerializeField] private float maxX = 7f;

    [SerializeField] private float minY = -4f;
    [SerializeField] private float maxY = 4f;

    [Header("回転")]
    [SerializeField] private bool randomRotation = true;

    [SerializeField] private float minRotation = 0f;
    [SerializeField] private float maxRotation = 360f;

    public override IEnumerator ExecuteAttack(Transform enemy, Transform muzzle, Transform playerTransform)
    {
        int laserCount = Random.Range(minLaserCount, maxLaserCount + 1);

        List<GameObject> warnings = new List<GameObject>();
        List<Vector3> positions = new List<Vector3>();
        List<Quaternion> rotations = new List<Quaternion>();

        // 全警告線を生成
        for (int i = 0; i < laserCount; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Vector3 spawnPos = new Vector3(randomX, randomY, 0f);

            Quaternion rotation = Quaternion.identity;

            if (randomRotation)
            {
                float rot = Random.Range(minRotation, maxRotation);

                rotation = Quaternion.Euler(0f, 0f, rot);
            }

            GameObject warning =
                Instantiate(warningLinePrefab, spawnPos, rotation);

            warnings.Add(warning);
            positions.Add(spawnPos);
            rotations.Add(rotation);
        }

        // 予告時間
        yield return new WaitForSeconds(warningTime);

        // 予告線削除
        foreach (GameObject warning in warnings)
        {
            Destroy(warning);
        }

        // 全レーザー生成
        List<GameObject> lasers = new List<GameObject>();

        for (int i = 0; i < laserCount; i++)
        {
            GameObject laser =
                Instantiate(laserPrefab, positions[i], rotations[i]);

            lasers.Add(laser);
        }

        // レーザー継続
        yield return new WaitForSeconds(laserDuration);

        // 全レーザー削除
        foreach (GameObject laser in lasers)
        {
            Destroy(laser);
        }

        // 次の攻撃まで待機
        yield return new WaitForSeconds(shotInterval);
    }
}