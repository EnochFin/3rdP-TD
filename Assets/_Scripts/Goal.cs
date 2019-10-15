﻿using UnityEngine;

public class Goal : MonoBehaviour
{
    public float Damage;
    public Deconstructable Player;

    private void OnTriggerEnter(Collider collider)
    {
        //Now that's a lot of damage!
        Player.GetComponent<Damagable>().Damage(Damage);

        Debug.Log(collider.name);

        Destroy(collider.gameObject);
    }
}
