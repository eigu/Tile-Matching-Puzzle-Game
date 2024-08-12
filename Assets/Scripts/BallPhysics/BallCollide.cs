using UnityEngine;

public class BallCollide : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ICollidable collidableObject = collision.gameObject.GetComponent<ICollidable>();

        if (collidableObject != null) collidableObject.Collide(collision);
    }
}
