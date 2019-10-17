using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject Target;
    public float rotationSpeed;
    public float fireRate;
    public float dmg = 10f;
    public LineRenderer BulletTrail;

    float bulletTrailTime;
    float nextShot;
    float bulletTrailEraseTime;

    public int Id;

    public Turret(int id)
    {
        Id = id;
    }

    private void Start()
    {
        bulletTrailTime = fireRate / 2f;
        nextShot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (BulletTrail.enabled && Time.time > bulletTrailEraseTime)
        {
            BulletTrail.enabled = false;
        }
        if (Target != null)
        {
            transform.LookAt(Target.transform.position);

            if (Time.time >= nextShot)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hit);

        Target.SendMessage("Damage", dmg);
        nextShot = Time.time + fireRate;

        BulletTrail.SetPositions(new Vector3[] { transform.position, hit.point });
        bulletTrailEraseTime = Time.time + bulletTrailTime;
        BulletTrail.enabled = true;
    }

    public void SetTarget(GameObject target)
    {
        Target = target;
    }
}
