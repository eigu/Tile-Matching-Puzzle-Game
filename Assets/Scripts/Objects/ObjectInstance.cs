using UnityEngine;
using UnityEngine.Pool;

public class ObjectInstance : MonoBehaviour
{
    public ObjectPoolingManager ObjectPoolingManager { get; set; }

    [SerializeField]
    public IObjectPool<ObjectInstance> Pool { get; set; }
}
