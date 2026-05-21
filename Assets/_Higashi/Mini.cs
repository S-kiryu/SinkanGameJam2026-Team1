using UnityEngine;

public class Mini : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    //[SerializeField] private GameObject MiniPrefab;

    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform muzzle;

    [SerializeField] private float shootingInterval = 1;
    [SerializeField] private float bulletSpeed = 10;

    private float timer = 0f;

    void Update()
    {
        ShootMini();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);

            Destroy(obj);
        }
    }

    void ShootMini()
    {
        timer += Time.deltaTime;

        if( timer >= shootingInterval)
        {
            GameObject enemyTransform = GameObject.FindWithTag("Enemy");

            Vector3 direction = enemyTransform.transform.position - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion bulletRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            GameObject bullet = Instantiate(Bullet,muzzle.position,bulletRotation);

            if(bullet.TryGetComponent(out Rigidbody2D rb))
            {
                Vector2 velocity = bullet.transform.up * bulletSpeed;
                rb.linearVelocity = velocity;
            }

            timer = 0;
        }
    }

    //public void AddMini(Transform playerT)
    //{
    //    Instantiate(MiniPrefab,playerT.position,Quaternion.identity);
    //}
}