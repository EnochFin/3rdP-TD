using System.Collections.Generic;
using UnityEngine;

public class QuickBarDisplay : MonoBehaviour
{
    public List<SlotDisplay> displays;

    public void UpdateDisplay(List<Item> items, int selectedIndex)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].deployed)
            {
                displays[i].Deploy();
            }
            else
            {
                displays[i].UnDeploy();
            }
            if (i == selectedIndex)
            {
                displays[i].Select();
            }
            else
            {
                displays[i].Deselect();
            }
        }
    }
}
