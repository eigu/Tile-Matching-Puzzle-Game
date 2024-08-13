using UnityEngine;

public class BallCollide : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        ICollidable collidableObject = collision.gameObject.GetComponentInChildren<ICollidable>();

        if (collidableObject != null) collidableObject.Collide(collision);
    }
}
