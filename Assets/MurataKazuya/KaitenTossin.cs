using UnityEngine;
using System.Collections;

public class KaitenTossin : MonoBehaviour
{

    bool Switch = false;
    [SerializeField] private Transform startBoss;

    private float minDistance = 2f;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] public float _rotateSpeed = 1f;
    [SerializeField] private Transform Player;
    private void Start()
    {
        StartCoroutine(ExecuteForSeconds(10.0f));
    }
    IEnumerator ExecuteForSeconds(float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            CheckDistance();

            float distance = Vector3.Distance(transform.position, Player.position);
            transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime);

            //Debug.Log(distance);

            if (Player != null && Switch == false)
            {
                Vector3 direction = (Player.position - transform.position);
                transform.position += direction.normalized * _moveSpeed * Time.deltaTime;

            }
            else if (Player != null && Switch == true)
            {

            }
            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = startBoss.position;
        transform.rotation = Quaternion.identity;
    }

 
    void CheckDistance()
    {
        GameObject playerT = GameObject.FindGameObjectWithTag("Player");

        float distance = Vector2.Distance(transform.position, playerT.transform.position);

        if (distance <= minDistance)
        {
            Switch = true;
        }
        else
        {
            Switch = false;
        }

    }
}
