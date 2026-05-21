using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class KaitenTossin : MonoBehaviour
{
    
    bool Switch = false;
    [SerializeField] private Transform startBoss;
    
    private float minDistance = 2f;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] public float _rotateSpeed = 1f;
    [SerializeField] private Transform Player;

    void Update()
    {
        CheckDistance();

        float distance = Vector3.Distance(transform.position, Player.position);
        transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime);

        Debug.Log(distance);

        if (Player != null && Switch == false)
        {
            Vector3 direction = (Player.position - transform.position);
            transform.position += direction.normalized * _moveSpeed * Time.deltaTime;

        }
        else if(Player != null && Switch == true)
        {

        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            {
                //Vector3 enddirection = (startBoss.position - transform.position);
                //transform.position += enddirection.normalized * moveSpeed * Time.deltaTime;

                //transform.position = Vector3.MoveTowards(transform.position, startBoss.position, _moveSpeed * Time.deltaTime);
                Switch = true;
            }
        }

    }

    void CheckDistance()
    {
        GameObject playerT = GameObject.FindGameObjectWithTag("Player");

        float distance = Vector2.Distance(transform.position, playerT.transform.position);

        if(distance <= minDistance)
        {
            Switch = true;
        }
        else
        {
            Switch = false;
        }

    }
}
