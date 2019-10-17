using UnityEngine;

public class Gun : MonoBehaviour
{
    public LineRenderer LineRender;
    public GameObject ShootSource;
    public GameObject SpawnObject;
    public QuickBar QuickBar;

    public float range = 100f;
    public float spawnDelay = 10f;
    public float lineDisplayTime = .5f;

    float nextSpawnTime;
    float removeLineRenderTime;

    private void Start()
    {
        nextSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Deploy();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            DestroyObj();
        }
        if (LineRender.enabled && Time.time > removeLineRenderTime)
        {
            LineRender.enabled = false;
        }
    }

    void Deploy()
    {
        RaycastHit hit;

        var didHit = Physics.Raycast(ShootSource.transform.position, ShootSource.transform.forward, out hit, range);

        if (didHit && Time.time > nextSpawnTime)
        {
            var hitDirection = (hit.point - transform.position).normalized;
            Physics.Raycast(transform.position, hitDirection, out RaycastHit gunHit);
            
            LineRender.SetPositions(new Vector3[] { transform.position, hit.point });
            removeLineRenderTime = Time.time + lineDisplayTime;
            LineRender.enabled = true;

            var status = QuickBar.DeployItem(QuickBar.SelectedIndex, gunHit.point);
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void DestroyObj()
    {
        RaycastHit hit;

        var didHit = Physics.Raycast(ShootSource.transform.position, ShootSource.transform.forward, out hit, range);

        if (didHit)
        {
            if (hit.collider.CompareTag("Destroyable"))
            {
                var id = hit.collider.gameObject.GetInstanceID();
                QuickBar.Return(id);
                Destroy(hit.collider.gameObject);
            }
        }
    }

    private void Spawn(Vector3 spawnLoc)
    {
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(SpawnObject, spawnLoc, Quaternion.identity);
    }
}
