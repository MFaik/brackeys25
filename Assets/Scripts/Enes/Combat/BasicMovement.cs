using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float movementSpeed, angularSpeed;

    Rigidbody2D playerRigidBody;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 velocity = Vector2.zero;
        float angularVelocity = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity += Vector2.down;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += Vector2.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += Vector2.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            angularVelocity += 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            angularVelocity += -1f;
        }

        playerRigidBody.linearVelocity = velocity * movementSpeed;
        playerRigidBody.angularVelocity = angularVelocity * angularSpeed;
    }
}
