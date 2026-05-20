using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float ShootingInterval;
    public float ShootingTime = 0f;
    public float BulletSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;

    private CharacterStatus _characterStatus;

    void Start()
    {
        _characterStatus = GetComponent<CharacterStatus>();
    }
    // Update is called once per frame
    void Update()
    {
        ShootingTime += Time.deltaTime;

        if (ShootingTime >= ShootingInterval)
        {
            GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);

            if (bullet.TryGetComponent(out Bullet bulletComponent) && _characterStatus != null)
            {
                bulletComponent.SetAttackPower(_characterStatus.Attack);
            }

            if (bullet.TryGetComponent(out Rigidbody2D rb2D))
            {
                Vector2 velocity = muzzle.up * BulletSpeed;
                rb2D.linearVelocity = velocity;
            }

            ShootingTime = 0f;
        }
    }
}
