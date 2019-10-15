using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Head, Player;
    public float RotationSpeed = 1;

    float mouseX, mouseY;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
    }

    void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;

        mouseY = Mathf.Clamp(mouseY, -35, 60);//stops camera from glitching out

        Head.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);

        transform.LookAt(Head);
    }
}
