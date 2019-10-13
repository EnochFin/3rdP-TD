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

    private void FixedUpdate()
    {
        moveDirection.y += Physics.gravity.y * fallSpeed * Time.deltaTime;
    }

    private void Update()
    {
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
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
    }
}
