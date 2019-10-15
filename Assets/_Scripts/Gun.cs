using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public LineRenderer LineRender;
    public GameObject PlayerCam;
    public GameObject SpawnObject;
    public TextMeshProUGUI HudTowerCountDisplay;

    public float damage = 10f;
    public float range = 100f;
    public float spawnDelay = 10f;
    public float lineDisplayTime = .5f;
    public float maxTurretCount = 2f;

    float turretCount;
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
            LineRender.enabled = false;
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        var didHit = Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, range);

        if (didHit)
        {

            var hitDirection = (hit.point - transform.position).normalized;
            Physics.Raycast(transform.position, hitDirection, out RaycastHit gunHit);

            if (CanSpawn())
            {
                Spawn(gunHit.point);
                LineRender.SetPositions(new Vector3[] { transform.position, hit.point });
                removeLineRenderTime = Time.time + lineDisplayTime;
                LineRender.enabled = true;
            }
        }
    }

    void DestroyObj()
    {
        RaycastHit hit;

        var didHit = Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, range);

        if (didHit)
        {
            if (hit.collider.CompareTag("Destroyable"))
            {
                Destroy(hit.collider.gameObject);
                turretCount -= 1;
            }
        }
        UpdateTowerCount();
    }

    private void Spawn(Vector3 spawnLoc)
    {
        turretCount += 1;
        nextSpawnTime = Time.time + spawnDelay;
        UpdateTowerCount();
        Instantiate(SpawnObject, spawnLoc, Quaternion.identity);
    }

    private void UpdateTowerCount()
    {
        HudTowerCountDisplay.text = $"Towers: {turretCount}/{maxTurretCount}";
    }

    private bool CanSpawn()
    {
        return Time.time >= nextSpawnTime && turretCount < maxTurretCount;
    }
}
