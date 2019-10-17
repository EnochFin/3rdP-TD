using UnityEngine;

public class Item : Object
{
    public string Name;
    public bool deployed;
    public GameObject turret;
    public int InstanceId;

    public Item(GameObject turret)
    {
        this.turret = turret;
    }
}
