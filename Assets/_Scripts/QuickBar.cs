using System.Collections.Generic;
using UnityEngine;

public class QuickBar : MonoBehaviour
{
    public int MaxItemCount = 4;
    public int SelectedIndex = 0;

    public GameObject DefaultItem;

    private List<Item> store;

    public QuickBarDisplay display;

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

    public void SelectItem()
    {
        SelectedIndex = GetNextIndex();

        display.UpdateDisplay(store, SelectedIndex);
    }

    //returns status message meant to be displayed
    public string DeployItem(int i, Vector3 deploymentLocation)
    {
        if (i < 0 || store[i].deployed)
        {
            return "Cannot deploy Item already deployed!";
        }

        Debug.Log($"Deployed: {i}");
        store[i].InstanceId = Instantiate(store[i].turret.gameObject, deploymentLocation, Quaternion.identity).GetInstanceID();
        store[i].deployed = true;

        SelectItem();
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
        SelectItem();
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

    private int GetNextIndex()
    {
        var start = SelectedIndex < 0 ? 0 : SelectedIndex;
        for (int i = 0; i < store.Count; i++)
        {
            var index = (start + i) % store.Count;
            if (!store[index].deployed)
                return index;
        }
        return -1;
    }
}
