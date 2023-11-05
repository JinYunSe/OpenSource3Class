using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMove : MonoBehaviour
{
    [Range(0,1f)]
    public float moveSpeed;
    [Range(0,1f)]
    public float rotationSpeed;
    public float maxY, minY;

    private int sign = 1;

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0));
        transform.position += new Vector3(0, moveSpeed * sign, 0);
        if (transform.position.y <= minY || transform.position.y >= maxY) sign *= -1;
    }
}
