using UnityEngine;

public class miniShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private float _shootingInterval = 0.5f;
    [SerializeField] private float _bulletSpeed = 5f;
    [SerializeField] private int _bulletDamage = 1;
    private float lastShootTime;

    private void Update()
    {
        lastShootTime += Time.deltaTime;
        Shoot();
    }

    private void Shoot()
    {
        if (_bulletPrefab == null || _muzzle == null) return;
        if (lastShootTime >= _shootingInterval)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _muzzle);

            if (bullet.TryGetComponent(out Bullet bulletComponent))
            {
                bulletComponent.SetAttackPower(_bulletDamage);
            }

            if (bullet.TryGetComponent(out Rigidbody2D rb2D))
            {
                Vector2 velocity = bullet.transform.up * _bulletSpeed;
                rb2D.linearVelocity = velocity;
            }
            lastShootTime = 0f;
        }
    }
}
