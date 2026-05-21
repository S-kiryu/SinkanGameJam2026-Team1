using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    public float SpawnTime = 5f;

    private float _attackPower;

    public void SetAttackPower(float attackPower)
    {
        _attackPower = attackPower;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;

        BossStatus status = collision.GetComponent<BossStatus>();

        if (status != null)
        {
            int totalDamage = Mathf.RoundToInt(damage + _attackPower);

            status.TakeDamage(totalDamage);

            DamageTextManager.Instance.ShowDamage(totalDamage, collision);

            ScoreManager.Instance.AddScore(damage);
            AudioManager.Instance.PlaySE("Damage");
        }

        Destroy(gameObject);
    }
}
