using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;

    public int BulletCount = 1;
    public float TotalAngle = 60f;

    public float ShootingInterval = 0.5f;
    public float ShootingTime = 0f;
    public float BulletSpeed = 10f;

    private CharacterStatus _characterStatus;

    void Start()
    {
        _characterStatus = GetComponent<CharacterStatus>();
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (bulletPrefab == null || muzzle == null) return;

        ShootingTime += Time.deltaTime;

        if (ShootingTime < ShootingInterval) return;

        int bulletCount = Mathf.Max(1, BulletCount);

        if (bulletCount == 1)
        {
            FireBullet(0f);
        }
        else
        {
            float angleStep = TotalAngle / (bulletCount - 1);
            float startAngle = -TotalAngle / 2f;

            for (int i = 0; i < bulletCount; i++)
            {
                float currentAngle = startAngle + angleStep * i;
                FireBullet(currentAngle);
            }
        }

        ShootingTime = 0f;
    }

    void FireBullet(float angleOffset)
    {
        Quaternion bulletRotation = muzzle.rotation * Quaternion.Euler(0f, 0f, angleOffset);
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, bulletRotation);

        if (bullet.TryGetComponent(out Bullet bulletComponent) && _characterStatus != null)
        {
            bulletComponent.SetAttackPower(_characterStatus.Attack);
        }

        if (bullet.TryGetComponent(out Rigidbody2D rb2D))
        {
            Vector2 velocity = bullet.transform.up * BulletSpeed;
            rb2D.linearVelocity = velocity;
        }
    }
}