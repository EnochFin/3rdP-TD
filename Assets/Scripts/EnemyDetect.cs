using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    //Object to Notify
    public Turret Notifee;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            Notifee.SetTarget(coll.gameObject);
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            Notifee.SetTarget(null);
        }
    }
}
