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

    private void Start()
    {
        direction = new Vector3(0f, 0f, -speed);
    }

    private void FixedUpdate()
    {
        if (ctrl.isGrounded)
        {
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

    // Update is called once per frame
    void Update()
    {
        ctrl.Move(direction * Time.deltaTime);
    }
}
