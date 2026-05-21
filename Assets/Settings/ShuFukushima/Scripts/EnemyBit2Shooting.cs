using System;
using UnityEngine;

public class EnemyBit2Shooting : MonoBehaviour
{
    [SerializeField] public int bulletSpeed = 5;
    [SerializeField] public float shotSpan = 0.01f;
    [SerializeField] private float nowTime = 0f;
    [SerializeField] private float fireTime = 5f;
    [SerializeField] private float spawnTime = 0;
    [SerializeField] private float fireEnd = 0f;
    [SerializeField] private Vector3 playerDir;
    [SerializeField] private bool isDir = false;
    [SerializeField] private bool isFire = false;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private GameObject enemyBulletPrefab;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTime >= fireTime)
        {
            if (nowTime >= shotSpan)
            {
                if(isDir == false)
                {
                    playerDir = (player.transform.position - muzzle.transform.position).normalized;

                    isDir = true;
                }

                float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;

                // 生成位置を取得
                Vector3 playerPos = muzzle.transform.position;
                // 弾を生成
                GameObject bullet = Instantiate(enemyBulletPrefab, muzzle.transform.position, Quaternion.Euler(0, 0, angle - 90f));

                Destroy(bullet, 5f);

                if (bullet.TryGetComponent(out Rigidbody2D rb2D))
                {
                    Vector2 velocity = playerDir * bulletSpeed;
                    rb2D.linearVelocity = velocity;
                }

                nowTime = 0;
            }

            nowTime += Time.deltaTime;
            isFire = true;
        }
        else
        {
            spawnTime += Time.deltaTime;
        }

        if (isFire)
        {
            fireEnd += Time.deltaTime;
        }

        if(fireEnd >= 3)
        {
            Destroy(gameObject);
        }


    }
}
