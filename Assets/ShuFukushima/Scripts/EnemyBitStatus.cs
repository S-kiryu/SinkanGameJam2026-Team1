using UnityEngine;

public class EnemyBitStatus : MonoBehaviour
{
    [SerializeField] private int hp = 3;
    private float _currentHp;

    private void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") && !collision.CompareTag("EnemyBullet"))
        {
            hp--;

            if (!collision.CompareTag("Player"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
