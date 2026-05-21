using UnityEngine;

public class EnemyBitShooting : MonoBehaviour
{
    [SerializeField] public int bulletSpeed = 5;
    [SerializeField] public float shotSpan = 3f;
    [SerializeField] private float nowTime = 0f;
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

        if(nowTime >= shotSpan)
        {
            Vector3 playerDir = (player.transform.position - muzzle.transform.position).normalized;

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

    }
}
