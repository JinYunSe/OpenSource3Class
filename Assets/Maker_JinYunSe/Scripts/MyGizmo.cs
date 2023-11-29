using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour
{
    public Color color = Color.yellow;
    public float radius = 0.1f;

    // Start is called before the first frame update
    void OnDrawGizmos()
    {
        // ����� ���� ����
        Gizmos.color = color;
        // �� ������ ����� ����
        Gizmos.DrawSphere(transform.position, radius);
    }
}
