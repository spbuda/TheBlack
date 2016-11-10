using UnityEngine;
using System.Collections;

[System.Serializable] public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;
    public float zClamp;
    public float jumpPower;
    public float secondJumpMod;
    public float maxMoveSpeed;
    public float groundRayLength = 0;

    private Rigidbody rb;
    private Vector3 groundRay = new Vector3(0, -1, 0);
    private bool grounded;
    private bool jumpTwo;
    

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        bool jump = Input.GetButtonDown("Jump");
        //Debug.Log(jump); //outputs jump to the console
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        if (movement.x > 0 && rb.velocity.x < maxMoveSpeed)
        {
            rb.velocity = rb.velocity + movement * speed;
        }
        else if (movement.x < 0 && rb.velocity.x > -maxMoveSpeed)
        {
            rb.velocity = rb.velocity + movement * speed;
        }

        grounded = false;

        if (Physics.Raycast(rb.position, groundRay, groundRayLength))
        {
            grounded = true;
            jumpTwo = true;

        }

        if (jump)
        {
            if (grounded)
            {
                Vector3 momentum = rb.velocity;
                Vector3 jumpOne = new Vector3(momentum.x, jumpPower, momentum.z);
                rb.velocity = jumpOne;
            }
            else
            {
                if (jumpTwo)
                {
                    jumpTwo = false;
                    Vector3 momentum = rb.velocity;
                    Vector3 jumpAgain = new Vector3(momentum.x, jumpPower * secondJumpMod, momentum.z);
                    rb.velocity = jumpAgain;
                }
            }
        }

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
            zClamp
        );
	}
}
