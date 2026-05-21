using UnityEngine;

public class EnemyBit2Mover : MonoBehaviour
{
    [SerializeField] private float stateTime;
    [SerializeField] private float nowTime = 0f;
    [SerializeField] private float speed = 1;
    [SerializeField] private int rnd;
    [SerializeField] private GameObject player;
    [SerializeField] private float fireTime = 5f;
    [SerializeField] private float spawnTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if(spawnTime <= fireTime)
        {
            // 上下左右に移動（左右移動を多めに）
            if (nowTime >= stateTime)
            {
                rnd = Random.Range(0, 10); // ※ 0～9の範囲でランダムな整数値が返る
                nowTime = 0f;
            }

            if (rnd == 8)
            {
                transform.position += new Vector3(0, speed, 0);
            }
            else if (rnd == 9)
            {
                transform.position += new Vector3(0, -speed, 0);
            }
            else if (rnd >= 0 && rnd <= 3)
            {
                transform.position += new Vector3(speed, 0, 0);
            }
            else if (rnd > 3 && rnd <= 7)
            {
                transform.position += new Vector3(-speed, 0, 0);
            }


            // 向きをプレイヤーに固定
            Vector3 playerDir = (player.transform.position - this.transform.position).normalized;

            float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;

            this.transform.rotation = Quaternion.Euler(0, 0, angle + 90);


            nowTime += Time.deltaTime;
        }

        spawnTime += Time.deltaTime;


    }
}
