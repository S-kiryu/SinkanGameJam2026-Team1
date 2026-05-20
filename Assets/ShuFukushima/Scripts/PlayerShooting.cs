using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;

 public int BulletCount = 1;
    public float TotalAngle = 60;

    public float ShootingInterval;
    public float ShootingTime = 0f;
    public float BulletSpeed;

    private CharacterStatus _characterStatus;

    void Start()
    {
        _characterStatus = GetComponent<CharacterStatus>();
    }
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        ShootingTime += Time.deltaTime;

        if (ShootingTime >= ShootingInterval)
        {
            float angleStep = TotalAngle / (BulletCount - 1);

            float startAngle = -TotalAngle / 2f;

            for (int i = 0;  i < BulletCount; i++)
            {
                float currentAngle = startAngle + angleStep * i;

                Quaternion bulletRotation = muzzle .rotation * Quaternion.Euler(0,0,currentAngle);

                GameObject bullet = Instantiate(bulletPrefab,muzzle.position, bulletRotation);

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

            ShootingTime = 0f;
        }
        
    }
}
