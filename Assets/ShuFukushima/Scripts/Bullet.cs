using UnityEngine;

public class Bullet : MonoBehaviour
{
   // [SerializeField] private GameObject damageText;

    public float SpawnTime = 5f;
    [SerializeField] private int damage = 1;

    private float _attackPower;


    public void SetAttackPower(float attackPower)
    {
        _attackPower = attackPower;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var status = collision.GetComponent<BossStatus>();

            if (status != null)
            {
                status.TakeDamage(damage + _attackPower);
            }
            Debug.Log("Enemy‚É“–‚½‚Á‚½");
            Destroy(gameObject);

            //if (damageText != null)
            //{
            //    Vector3 spawnPos = collision.transform.position + new Vector3(0, 0.5f, 0);

            //    GameObject popupDamage = Instantiate(damageText, spawnPos, Quaternion.identity);
            //    DamageText textPopup = popupDamage.GetComponent<DamageText>();

            //    textPopup.Setup(damage);
            //}
        }
    }
}