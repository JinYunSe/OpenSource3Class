using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 10.0f; //속도
    public float gravity = 9.8f; //중력
    public Ray ray = new Ray();
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) == true)
        {
            playerRB.velocity = Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            playerRB.velocity = Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.W) == true)
        {
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            playerRB.velocity = Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            //transform.Translate(Vector3.back * speed * Time.deltaTime);
            playerRB.velocity = Vector3.back * speed;
        }
        if (Input.GetKey(KeyCode.Space) == true)
        {
            playerRB.AddForce(Vector3.up * speed * 5);
        }
    }
    private void FixedUpdate()
    {

    }

}
