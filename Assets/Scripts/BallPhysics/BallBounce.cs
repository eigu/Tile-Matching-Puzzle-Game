using UnityEngine;

public class BallBounce : MonoBehaviour, ICollidable
{
    public void Collide(Collision2D collision)
    {
        BallMove ballMovement = collision.gameObject.GetComponent<BallMove>();

        if (ballMovement != null)
        {
            //ballMovement.Direction = Vector2.Reflect(ballMovement.Direction, collision.contacts[0].normal);
        }
    }
}
