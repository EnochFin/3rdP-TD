using TMPro;
using UnityEngine;

public class DamageDisplay : MonoBehaviour
{
    public TextMeshProUGUI DisplayText;

    public void Display(float health)
    {
        DisplayText.text = $"Health: {health}";
    }
}
