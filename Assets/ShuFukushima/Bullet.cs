using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float SpawnTime = 5f;
    [SerializeField]private int damage = 1;

    private float _attackPower;


    public void SetAttackPower(float attackPower)
    {
        _attackPower = attackPower;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet‚ª‰½‚©‚É“–‚½‚Á‚½");
        if (collision.CompareTag("Enemy"))
        {
            var status = collision.GetComponent<BossStatus>();

            if (status != null)
            {
                status.TakeDamage(damage+_attackPower);
            }
            Debug.Log("Enemy‚É“–‚½‚Á‚½");
            Destroy(gameObject);
        }
    }
}
