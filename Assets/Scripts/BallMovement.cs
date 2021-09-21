using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public Rigidbody ballBody;
    public float ballSpeed = 5f;
    public float ballJumpForce = 50f;
    public bool ballOnGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Roll();
        Jump();
    }

    void Roll()
    {
        float movementX = Input.GetAxisRaw("Horizontal") * ballSpeed * Time.fixedDeltaTime;
        float movementZ = Input.GetAxisRaw("Vertical") * ballSpeed * Time.fixedDeltaTime;

        ballBody.AddForce(new Vector3(movementX, 0, movementZ));
    }

    void Jump()
    {
        if(ballOnGround == true)
        {
            float jumpY = ballJumpForce * Time.fixedDeltaTime;
            if (Input.GetKey(KeyCode.Space))
            {
                ballBody.AddForce(new Vector3(0, jumpY, 0), ForceMode.Impulse);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            ballOnGround = true;
        }
        else if(other.gameObject.tag == "finish")
        {
            Application.Quit();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            ballOnGround = false;
        }
    }

}
