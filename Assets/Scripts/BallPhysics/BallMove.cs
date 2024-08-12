using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    public Vector2 Direction { get; set; }

    private void Start()
    {
        Direction = new Vector2(1f, 1f).normalized; 
    }

    private void Update()
    {
        transform.Translate(Direction * _speed * Time.deltaTime);
    }
}