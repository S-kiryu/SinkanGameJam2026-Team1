using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float SpawnTime = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, SpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
