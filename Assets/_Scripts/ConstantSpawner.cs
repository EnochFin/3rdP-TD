using System.Collections.Generic;
using UnityEngine;

public class ConstantSpawner : MonoBehaviour
{
    public GameObject spawnObject;
    public float spawnTime;

    float nextSpawnTime;

    List<GameObject> spawnedObjects = new List<GameObject>();

    private void Start()
    {
        nextSpawnTime = Time.time;

        if (spawnedObjects.Count > 0)
        {
            foreach (var o in spawnedObjects)
            {
                Destroy(o);
            }
        }
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime += spawnTime;
            var spawnedObj = Instantiate(spawnObject, transform.position, transform.rotation);

            spawnedObjects.Add(spawnedObj);
        }
    }
}
