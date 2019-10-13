using UnityEngine;

public class Gun : MonoBehaviour
{
    public LineRenderer LineRender;
    public Camera playerCam;
    public GameObject spawnObject;

    public float damage = 10f;
    public float range = 100f;
    public float spawnDelay = 10f;
    public float lineDisplayTime = .5f;

    float nextSpawnTime;
    float removeLineRenderTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            DestroyObj();
        }
        if (LineRender.enabled && Time.time > removeLineRenderTime)
        {
            Debug.Log("Removed LineRender");
            LineRender.enabled = false;
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        var didHit = Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range);

        if (didHit)
        {
            Debug.Log($"Ending Display of line at: {removeLineRenderTime}");

            if (CanSpawn())
            {
                Spawn(hit.point);
                LineRender.SetPositions(new Vector3[] { transform.position, hit.point });
                removeLineRenderTime = Time.time + lineDisplayTime;
                LineRender.enabled = true;
            }
            Debug.Log(hit.transform.name);
        }
        else
        {
            Debug.Log("miss!");
        }
    }

    void DestroyObj()
    {
        RaycastHit hit;

        var didHit = Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range);

        if (didHit)
        {
            if (hit.collider.CompareTag("Destroyable"))
            {
                Destroy(hit.collider.gameObject);
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
