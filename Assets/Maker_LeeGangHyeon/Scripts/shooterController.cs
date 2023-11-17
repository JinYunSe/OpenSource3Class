using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, -10f, 0f));
        }
        else if (Input.GetKey(KeyCode.D) == true)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 10f, 0f));
        }
        else 
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
    }
}
