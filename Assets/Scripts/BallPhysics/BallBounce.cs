using UnityEngine;

public class BallBounce : MonoBehaviour, ICollidable
{
    public void Collide(Collision2D collision)
    {
        Debug.Log($"Collided to {collision.collider.tag}");

        BallMove ballMove = collision.collider.GetComponent<BallMove>();

        if (ballMove != null)
        {
            Vector2 normal = collision.GetContact(0).normal;

            //Vector2 newDirection = Vector2.Reflect(ballMove.GetDirection(), normal);

            //ballMove.SetDirection(newDirection);
        }
    }
}