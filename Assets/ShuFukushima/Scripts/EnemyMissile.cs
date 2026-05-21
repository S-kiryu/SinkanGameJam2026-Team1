using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    public float SpawnTime = 5f;
    public float MissileSpeed = 3f;
    public float NowFollw = 0f;
    public float FollowTime = 3f;
    [SerializeField] private int damage = 3;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rb2D;
    public Vector3 LastPlayerDir;
  

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(NowFollw < FollowTime)
        {
            Vector3 playerDir = (player.transform.position - transform.position).normalized;

            float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

            Vector2 velocity = playerDir * MissileSpeed;
            rb2D.linearVelocity = velocity;

            LastPlayerDir = playerDir;
            NowFollw += Time.deltaTime;
        }
        else
        {
            Vector2 velocity = LastPlayerDir * MissileSpeed;
            rb2D.linearVelocity = velocity;
        }

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
