using UnityEngine;

public class RasenAttack : MonoBehaviour
{
    [SerializeField] public float _rotateSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0, 0, -10);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime);
    }
}
