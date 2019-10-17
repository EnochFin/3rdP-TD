using System.Collections.Generic;
using UnityEngine;

public class QuickBarDisplay : MonoBehaviour
{
    public GameObject SelectSprite;
    public GameObject Deployed;
    private readonly int startX = 105;
    private readonly int width = 61;

    public void UpdateDisplay(List<Item> items, int selectedIndex)
    {
        var x = startX + width * selectedIndex;
        SelectSprite.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, SelectSprite.transform.localPosition.y);
        //decide how to signify deployed
        //for (int i = 0; i < items.Count; i++)
        //{
        //    if (items[i].deployed)
        //    {
        //        SelectSprite.transform.GetComponent<RectTransform>().localPosition = new Vector3(startX + 61 * i, SelectSprite.transform.localPosition.y);
        //    }
        //}
    }
}
