using UnityEngine.SceneManagement;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float PlayerSpeed;
    public float JumpHeight;
    public float fallSpeed;

    Vector3 moveDirection;
    float hor;
    float ver;

    private void Start()
    {
        Debug.Log("eskeetit");
    }

    private void Update()
    {
        if (transform.position.y < -100)
        {
            SceneManager.LoadScene("MainLevel");
        }

        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        moveDirection = new Vector3(hor * PlayerSpeed, moveDirection.y, ver * PlayerSpeed);

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = JumpHeight;
            }
        }
        moveDirection.y += Physics.gravity.y * fallSpeed;

        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
    }
}
