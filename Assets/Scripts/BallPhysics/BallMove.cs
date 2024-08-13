using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetInitialDirection();
    }

    private void Update()
    {
        rb.velocity = transform.up * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 incomingDirection = rb.velocity.normalized;
            Vector2 reflectedDirection = Vector2.Reflect(incomingDirection, collision.contacts[0].normal);
            rb.velocity = reflectedDirection * _speed;
        }
    }

    private void SetInitialDirection()
    {
        rb.velocity = transform.up * _speed;
    }
}
