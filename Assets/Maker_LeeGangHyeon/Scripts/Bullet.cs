using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * -1f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals("Default"))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer.Equals("Default"))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer.Equals("Default"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals("Default"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer.Equals("Default"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer.Equals("Default"))
        {
            Destroy(gameObject);
        }
    }
}
