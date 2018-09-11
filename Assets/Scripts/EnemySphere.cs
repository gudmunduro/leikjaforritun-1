using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySphere : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 500f;

    private Vector3 currentDirection = new Vector3(0f, 0f, 0f);
    private bool movingForward = true;
    private int pos = 0;

    private void Start ()
    {
        recalculateDirection();

    }
	
	private void Update ()
    {
        if (movingForward)
        {
            pos += 10;
            rb.AddForce(transform.forward * 500f * Time.deltaTime);
            if (pos == 100)
            {
                movingForward = false;
            }
        }
        else
        {
            pos -= 10;
            rb.AddForce(transform.forward * -500f * Time.deltaTime);
            if (pos == 0)
            {
                movingForward = true;
            }
        }
        /*if (rb.position.x < -24.53518)
        {
            rb.AddForce(new Vector3(100, 0, 0));
            recalculateDirection();
            return;
        }
        if (rb.position.x > 14.07791)
        {
            rb.AddForce(new Vector3(-100, 0, 0));
            recalculateDirection();
            return;
        }
        if (rb.position.y < 48.70194)
        {
            rb.AddForce(new Vector3(0, 0, 100));
            recalculateDirection();
            return;
        }
        if (rb.position.y > 86.72186)
        {
            rb.AddForce(new Vector3(0, 0, -100));
            recalculateDirection();
            return;
        }
        rb.AddForce(new Vector3(currentDirection.x, 0, currentDirection.z));*/
    }

    private void recalculateDirection()
    {
        currentDirection.x = Random.Range(0f, 700f);
        currentDirection.y = Random.Range(0f, 700f);
    }
}
