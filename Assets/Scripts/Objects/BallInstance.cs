using UnityEngine;

public class BallInstance : ObjectInstance
{
    public Transform SpawnPoint;

    //private void OnEnable()
    //{
    //    ObjectPoolingManager.OnSpawn += Initialize;
    //}

    //private void OnDisable()
    //{
    //    ObjectPoolingManager.OnSpawn -= Initialize;
    //}

    //private void Initialize(ObjectInstance instance)
    //{
    //    if (instance == this)
    //    {
    //        if (SpawnPoint != null)
    //        {
    //            transform.position = SpawnPoint.position;
    //        }
    //        else
    //        {
    //            Debug.LogWarning("SpawnPoint is not set for the BallInstance.");
    //        }
    //    }
    //}
}
