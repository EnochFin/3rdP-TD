using UnityEngine;
using UnityEngine.UI;

public class SlotDisplay : MonoBehaviour
{
    public Image Selected;
    public Image Deployed;
    
    public void Select()
    {
        Selected.enabled = true;
    }

    public void Deselect()
    {
        Selected.enabled = false;
    }

    public void Deploy()
    {
        Deployed.enabled = true;
    }

    public void UnDeploy()
    {
        Deployed.enabled = false;
    }
}
