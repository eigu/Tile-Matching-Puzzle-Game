using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolingManager : MonoBehaviour
{
    [SerializeField]
    private ObjectInstance _objectPrefab;
    private ObjectInstance m_object;

    private IObjectPool<ObjectInstance> m_pool;
    [SerializeField]
    private int _poolDefaultCapacity;
    [SerializeField]
    private int _poolMaxSize;

    private void Start()
    {
        m_pool = new ObjectPool<ObjectInstance>(
        CreateObject,
        null,
        OnReleaseToPool,
        OnDestroyPooledObject,
        defaultCapacity: _poolDefaultCapacity,
        maxSize: _poolMaxSize);
    }

    public void Spawn()
    {
        m_object = m_pool.Get();
    }

    private ObjectInstance CreateObject()
    {
        ObjectInstance pooledObject = Instantiate(_objectPrefab);

        pooledObject.Pool = m_pool;

        return pooledObject;
    }

    private void OnReleaseToPool(ObjectInstance pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObject(ObjectInstance pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }
}