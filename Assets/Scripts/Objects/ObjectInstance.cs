using UnityEngine;
using UnityEngine.Pool;

public class ObjectInstance : MonoBehaviour
{
    [SerializeField]
    public IObjectPool<ObjectInstance> Pool { get; set; }
}
