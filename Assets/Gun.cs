using UnityEngine;

public class Gun : MonoBehaviour
{
    public LineRenderer LineRender;
    public Camera playerCam;
    public GameObject spawnObject;

    public float damage = 10f;
    public float range = 100f;
    public float spawnDelay = 10f;

    public float nextSpawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        var didHit = Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range);

        if (didHit)
        {
            LineRender.SetPositions(new Vector3[] { transform.position, hit.point});

            if (CanSpawn())
            {
                Spawn(hit.point);
            }
            Debug.Log(hit.transform.name);
        }
        else
        {
            Debug.Log("miss!");
        }
    }

    private void Spawn(Vector3 spawnLoc)
    {
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(spawnObject, spawnLoc, Quaternion.identity);
        Debug.Log($"Spoawned at: {spawnLoc}");
    }

    private bool CanSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
