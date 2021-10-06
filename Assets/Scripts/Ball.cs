using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    public Rigidbody ballBody;
    public Vector3 startPos;
    [SerializeField] private Text livesText;
    public float ballSpeed = 5f;
    public float ballJumpForce = 50f;
    public float minHeight;
    public int lives = 1;
    public bool ballOnGround;
    public bool ballCanMove;

    void Start()
    {
        startPos = new Vector3(0.07138065f, 3.01f, -3.37f);
    }

    void Update()
    {

        livesText.text = lives.ToString();

        if (ballOnGround is true)
        {
            ballCanMove = true;
        }

        if (BallIsDead() is true)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        if (ballCanMove is true)
        {
            Roll();
            Jump();
        }
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

    void Die()
    {
        ballCanMove = false;
        if (lives > 1)
        {
            lives--;
            Respawn();
        }
        else if (lives == 1)
        {
            lives--;
            print("GAME OVER");
        }
    }

    void Respawn()
    {
        this.gameObject.SetActive(false);
        transform.position = startPos;
        this.gameObject.SetActive(true);
        if (ballOnGround is false)
        {
            ballBody.velocity = new Vector3(0,0,0);
            ballBody.angularVelocity = new Vector3(0,0,0);   
        }
    }

    public bool BallIsDead()
    {
        if (transform.position.y < minHeight)
        {
            return true;
        }
        else
        {
            return false;
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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "heart")
        {
            Destroy(other.gameObject);
            lives++;
        }
    }

}
