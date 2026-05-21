using UnityEngine;

public class OrbitObject : MonoBehaviour
{
    [SerializeField] private Transform enemyTransform;

    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform muzzle;

    [SerializeField] private float shootingInterval = 1;
    [SerializeField] private float bulletSpeed = 10;

    private float timer = 0f;

    void Update()
    {
        ShootMini();
    }

    void ShootMini()
    {
        timer += Time.deltaTime;

        if( timer >= shootingInterval)
        {
            Vector3 direction = enemyTransform.position - transform.position;

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

}