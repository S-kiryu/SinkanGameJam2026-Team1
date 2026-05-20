using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float ShootingInterval;
    public float ShootingTime = 0f;
    public float BulletSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootingTime += Time.deltaTime;

        if(ShootingTime >= ShootingInterval)
        {
            // 生成位置を取得
            Vector3 playerPos = transform.position;
            // 弾を生成
            GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            
            if(bullet.TryGetComponent(out Rigidbody2D rb2D))
            {
                Vector2 velocity = muzzle.up * BulletSpeed;
                rb2D.linearVelocity = velocity;
            }

            ShootingTime = 0f;
        }





        // テスト用処理
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.2f, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.2f, 0, 0);
        }
    }
}
