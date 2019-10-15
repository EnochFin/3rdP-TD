using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Deconstructable
{
    public GameObject Owner;

    public override void Destroy()
    {
        Debug.Log("Destroyed!");
        SceneManager.LoadScene("MainLevel");
    }
}
