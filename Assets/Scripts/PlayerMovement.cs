using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;

    public GameObject Ball;


    public Vector3 InitialForce;

    // Update is called once per frame

    private BallScript ballScript;

    private Rigidbody rigidbodyBall;

    public float angleModifier = 2f;

    private void Start()
    {
        rigidbodyBall = Ball.GetComponent<Rigidbody>();
        ballScript = Ball.GetComponent<BallScript>();
        
    }
    void Update()
    {
        float inputSpeed = 0;

        inputSpeed = - Input.GetAxisRaw("Horizontal");

        Vector3 vector = new Vector3(MovementSpeed * inputSpeed * Time.deltaTime, 0f, 0f);

        transform.position += vector;

            if(Input.GetKeyDown(KeyCode.Space) && ballScript.StickToThePlayer)
            {
            ballScript.StickToThePlayer = false;
          
            rigidbodyBall.AddForce(InitialForce + vector, ForceMode.Impulse);

            }
          if (ballScript.StickToThePlayer)
            {
            Ball.transform.position = this.transform.position - new Vector3(0f,0f, 1.3f);
            }
    }

    public void OnCollisionEnter(Collision collision)
    {
        BallScript ball = collision.gameObject.GetComponent<BallScript>();
        Vector3 contact = collision.contacts[0].point;
        Rigidbody ballbody = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 playerCenter = this.gameObject.transform.position;
        float deltaX = angleModifier * Mathf.Abs(contact.x - playerCenter.x);
        if(ball != null && ballbody !=null)
        {
            ball.PlayRegular();

            ballbody.velocity = Vector3.zero;

            Vector3 con = new Vector3(deltaX, 0f, 0f);
            if(contact.x < playerCenter.x)
            {
                ballbody.AddForce(InitialForce - con, ForceMode.Impulse);
            }
            else
            {
                ballbody.AddForce(InitialForce + con, ForceMode.Impulse);
            }
        }
    }
}
