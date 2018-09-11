using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 500f;
    public float jumpForce = 4000f;

    private float turnSmoothVelocity;
    private Transform cameraT;
    private int groundHits = 0;

    private bool onGround
    {
        get
        {
            return groundHits > 0;
        }
    }


    private void Start()
    {

    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (onGround)
        {
            if (input != Vector2.zero)
            {
                float targetRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, 0.2f);

                rb.AddForce(transform.forward * forwardForce * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(0, jumpForce * Time.deltaTime, 0);
            }
        }

        if (Input.GetKey(KeyCode.K))
        {
            Debug.Log("x: " + rb.position.x + ", y: " + rb.position.y + ", z: " + rb.position.z);
        }
    }

    private void OnCollisionEnter(Collision hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Terrain":
                Debug.Log("terrain hit enter");
                groundHits++;
                break;
            case "Enemy":
                Debug.Log("Enemy collide");
                rb.AddForce(0, 20000 * Time.deltaTime, 0);
                break;
        }
    }
    private void OnCollisionExit(Collision hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Terrain":
                Debug.Log("terrain hit exit");
                if (groundHits > 0)
                {
                    groundHits--;
                }
                break;
        }
    }
}
