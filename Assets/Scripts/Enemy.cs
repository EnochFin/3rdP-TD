using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public CharacterController ctrl;
    public float speed;
    public GameObject Parent;
    public TextMeshPro TextMesh;
    //combine with Movement.cs?
    public float fallSpeed;
    public float health = 100;

    Vector3 direction;
    Random rand;

    private void FixedUpdate()
    {
        direction.x = transform.forward.x * speed;
        direction.z = transform.forward.z * speed;
        if (ctrl.isGrounded)
        {
            Debug.Log($"IsGrounded! {Parent.name}");
            direction.y = 0f;
        }
        else
        {
            direction.y += Physics.gravity.y * fallSpeed * Time.deltaTime;
        }
    }

    void Damage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Destroy(Parent);
        }

        TextMesh.text = $"Health: {health}";
    }

    void Rotate(Vector3 rotation)
    {
        Parent.transform.Rotate(rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(direction);
        ctrl.Move(direction * Time.deltaTime);
    }
}
