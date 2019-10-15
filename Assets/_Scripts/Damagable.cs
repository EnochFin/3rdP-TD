using UnityEngine;

public class Damagable : MonoBehaviour
{
    public float Health;
    public Deconstructable owner;

    DamageDisplay display;

    private void Start()
    {
        display = owner.GetComponent<DamageDisplay>();
        
        display.Display(Health);
    }

    public void Damage(float dmg)
    {
        Health -= dmg;

        if (display != null)
        {
            display.Display(Health);
        }

        if (Health <= 0)
        {
            owner.Destroy();
        }
    }
}
