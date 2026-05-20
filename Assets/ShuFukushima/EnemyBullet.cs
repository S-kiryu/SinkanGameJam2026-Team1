using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float SpawnTime = 5f;
    [SerializeField] private int damage = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var status = collision.GetComponent<CharacterStatus>();

            if (status != null)
            {
                status.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
