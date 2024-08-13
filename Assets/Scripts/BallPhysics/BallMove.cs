using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    private void Update()
    {
        transform.Translate(new Vector3(0, _speed, 0));
    }
}