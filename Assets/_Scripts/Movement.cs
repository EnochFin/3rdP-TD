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
    bool jump;

    private void FixedUpdate()
    {
        if (jump)
        {
            moveDirection.y = 0f;
            if (controller.isGrounded)
            {
                moveDirection.y = JumpHeight;
            }
        }
        moveDirection.y += Physics.gravity.y * fallSpeed * Time.deltaTime;
    }

    private void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        jump = Input.GetButtonDown("Jump");

        moveDirection = new Vector3(hor * PlayerSpeed, moveDirection.y, ver * PlayerSpeed);

        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
    }
}
