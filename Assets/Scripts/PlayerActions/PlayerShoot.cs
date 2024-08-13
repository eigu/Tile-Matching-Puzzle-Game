using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnPoint;

    public UnityEvent OnShoot;

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed) OnShoot?.Invoke();
    }

    public void Initialize(ObjectInstance instance)
    {
        instance.gameObject.transform.position = _spawnPoint.position;
    }
}
