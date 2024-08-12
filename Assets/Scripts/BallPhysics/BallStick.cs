using UnityEngine;

public class BallStick : MonoBehaviour, ICollidable
{
    public void Collide(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
}
