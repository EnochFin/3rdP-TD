using System.Collections.Generic;
using UnityEngine;

public class QuickBar : MonoBehaviour
{
    public int MaxItemCount = 4;
    public int SelectedIndex = 0;

    public GameObject DefaultItem;

    private List<Item> store;

    private QuickBarDisplay display;

    // Start is called before the first frame update
    void Start()
    {
        store = new List<Item>();

        for (int i = 0;i < MaxItemCount; i++)
        {
            var spawnee = DefaultItem;
            var item = new Item(spawnee);
            spawnee.GetComponent<Turret>().Id = i;
            store.Add(new Item(spawnee));
        }
    }

    public Item SelectItem(int i)
    {
        if (i >= store.Count)
        {
            i = 0;//loop around to the first item
        }

        display = GameObject.FindGameObjectWithTag("QuickBar").GetComponent<QuickBarDisplay>();

        SelectedIndex = i;
        display.UpdateDisplay(store, i);
        return store[i];
    }

    //returns status message meant to be displayed
    public string DeployItem(int i, Vector3 deploymentLocation)
    {
        if (store[i].deployed)
        {
            return "Cannot deploy Item already deployed!";
        }

        Debug.Log($"Deployed: {i}");
        store[i].InstanceId = Instantiate(store[i].turret.gameObject, deploymentLocation, Quaternion.identity).GetInstanceID();
        store[i].deployed = true;

        SelectItem(i + 1);
        return $"Deployed Slot{i + 1}";
    }

    public void Return(int i)
    {
        Debug.Log($"Returned: {i}");
        foreach(var item in store)
        {
            if (item.InstanceId == i)
            {
                item.deployed = false;
            }
        }
    }

    public bool RemoveItem(int i)
    {
        if (store[i] != null)
        {
            store[i] = null;
            return true;
        }
        return false;
    }
}
