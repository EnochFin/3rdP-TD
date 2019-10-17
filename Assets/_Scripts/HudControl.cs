using UnityEngine;

public class HudControl : MonoBehaviour
{
    public GameObject Panel;

    bool directions;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Panel.SetActive(directions);
            directions = !directions;
        }
    }
}
