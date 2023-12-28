using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    [SerializeField] private Joystick movement;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (movement.Direction.y !=0)
        {
            rb.velocity = new Vector2(movement.Direction.x * speed, movement.Direction.y * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
