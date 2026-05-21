using UnityEngine;

public class player : MonoBehaviour
{

    public float PlayerMove = 5;

    private Rigidbody2D _rigidbody2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        _rigidbody2D.linearVelocity = moveDirection * PlayerMove;
    }
}