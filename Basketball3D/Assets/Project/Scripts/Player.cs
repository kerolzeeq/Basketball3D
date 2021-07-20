using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Ball ball;
    public GameObject playercamera;

    public float ballThrowingForce = 500f;

    public bool holdingBall = false;
    // Start is called before the first frame update
    void Start()
    {
        ball.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingBall)
        {
            ball.GetComponent<Rigidbody>().useGravity = false;
            ball.transform.position = playercamera.transform.position + playercamera.transform.forward * 1.5f; // ball move with player camera
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;


            if (Input.GetMouseButtonDown(0))
            {
                holdingBall = false;
                ball.ActivateTrail();
                ball.GetComponent<Rigidbody>().useGravity = true;
                ball.GetComponent<Rigidbody>().AddForce(playercamera.transform.forward * ballThrowingForce);
            }
        }
    }
}
