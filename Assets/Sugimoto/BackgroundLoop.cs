using UnityEngine;

public class LoopImage : MonoBehaviour
{
    public float speed = 2f;
    public float height = 20f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y >= height)
        {
            transform.position -= new Vector3(0, height * 2f, 0);
        }
    }
}