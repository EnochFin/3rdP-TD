using UnityEngine.SceneManagement;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainLevel");
        }
        else
        {
            Destroy(collider.gameObject);
        }
    }
}
