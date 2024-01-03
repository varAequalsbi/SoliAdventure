using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TapToMove : MonoBehaviour
{
    //[SerializeField] private Player player;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float doubleClickTime = .3f;

    private Vector3 target;
    private bool moving;
    private float lastClickedTime;


    private void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
             float sinceLastClicked = Time.time - lastClickedTime;


            if (sinceLastClicked <= doubleClickTime)
            {
                moving = true;
                
            }
            else
            {
                moving= false;
            }

            lastClickedTime = Time.time;
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

        }
        if (moving && (Vector3)transform.position != target)
        {

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            moving = false;
        }

    }
}
