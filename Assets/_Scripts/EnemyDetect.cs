using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    //Object to Notify
    public Turret Notifee;
    public float range;

    private void Update()
    {
        var objectsInSphere = Physics.OverlapSphere(transform.position, range);

        var minDist = float.MaxValue;

        GameObject target = null;

        foreach(var obj in objectsInSphere)
        {
            if (!obj.CompareTag("Enemy"))
                continue;

            var dir = (obj.transform.position - transform.position).normalized;

            if (Physics.Raycast(transform.position, dir, out var hit))
            {
                if (hit.distance < minDist)
                {
                    target = obj.gameObject;
                    minDist = hit.distance;
                }
            }
        }
        Notifee.SetTarget(target);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
