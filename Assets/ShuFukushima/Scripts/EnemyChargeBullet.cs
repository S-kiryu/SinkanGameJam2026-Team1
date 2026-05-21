using UnityEngine;

public class EnemyChargeBullet : MonoBehaviour
{
    public float SpawnTime = 5f;
    [SerializeField] private int addDamage = 0;
    [SerializeField] public float chargeTime;
    [SerializeField] private float nowTime = 0f;
    [SerializeField] private int damage = 10;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private GameObject enemy;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // 一定時間大きくする処理
        if(nowTime <= chargeTime)
        {
            // 一定時間大きくする
            transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);

            // 一定時間マズル位置に追従
            transform.localPosition = enemy.transform.position - new Vector3(0f, 1.3f, 0f);

            // 一定時間でダメージが増える
            if((addDamage / 30) >= 1)
            {
                damage++;
                addDamage = 0;
            }
        }

        addDamage++;
        nowTime += Time.deltaTime;

    }


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
