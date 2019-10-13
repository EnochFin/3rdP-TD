using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float xRotation;
    public float yRotation;
    public float zRotation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.SendMessage("Rotate", new Vector3(xRotation, yRotation, zRotation));
        }
    }
}
