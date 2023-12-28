using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed = 7f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float drix = Input.GetAxisRaw("Horizontal");
        float driy = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(drix * speed, driy * speed);
        // rb.velocity = new Vector2();


    }
}
