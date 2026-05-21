using Unity.VisualScripting;
using UnityEngine;

public class KaitenTossin : MonoBehaviour
{   bool Switch = false;
    [SerializeField] private Transform startBoss;
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] public float _rotateSpeed = 1f;

    void Update()
    {
        transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime);
        if (player != null && Switch == false)
        {
            Vector3 direction = (player.position - transform.position);
            transform.position += direction.normalized * moveSpeed * Time.deltaTime;

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            {
                //Vector3 enddirection = (startBoss.position - transform.position);
                //transform.position += enddirection.normalized * moveSpeed * Time.deltaTime;
                //Switch = true;
                
            }
        }

    }
}
