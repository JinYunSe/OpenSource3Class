using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("Boxcast Property")]
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private int speed;

    [Header("Debug")]
    [SerializeField] private bool drawGizmo;

    private void OnDrawGizmos()
    {
        if (!drawGizmo) return;

        Gizmos.color = Color.magenta;
        //Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);

        // �Լ� �Ķ���� : ���� ��ġ, Box�� ���� ������, Ray�� ����, RaycastHit ���, Box�� ȸ����, BoxCast�� ������ �Ÿ�
        if (Physics.BoxCast(transform.position, boxSize / 2.0f, -transform.up, out RaycastHit hit, transform.rotation, maxDistance, groundLayer))
        {
            // Hit�� �������� ray�� �׷��ش�.
            Gizmos.DrawRay(transform.position, -transform.up * hit.distance);

            // Hit�� ������ �ڽ��� �׷��ش�.
            Gizmos.DrawWireCube(transform.position + - transform.up * hit.distance, boxSize);
            //Debug.Log("�浹");
        }
        else
        {
            // Hit�� ���� �ʾ����� �ִ� ���� �Ÿ��� ray�� �׷��ش�.
            Gizmos.DrawRay(transform.position, -transform.up * maxDistance);
        }

    }

    public int IsGrounded()
    {
        bool checker = Physics.BoxCast(transform.position, boxSize / 2.0f, -transform.up, out RaycastHit hit, transform.rotation, maxDistance, groundLayer);
        if (checker && hit.collider.CompareTag("JumpZone"))
        {
            Debug.Log("����");
            return 1;
        }
        else if (checker && hit.collider.CompareTag("SlowZone"))
        {
            return 2;
        }
        return 0;
    }

    public bool checkGround()
    {
        bool checker = Physics.BoxCast(transform.position, boxSize / 2.0f, -transform.up, out RaycastHit hit, transform.rotation, maxDistance, groundLayer);
        return checker;
    }

    public int CheckTrigger()
    {
        bool checker = Physics.BoxCast(transform.position, boxSize / 2.0f, -transform.up, out RaycastHit hit, transform.rotation, maxDistance, groundLayer);
        if (hit.collider.isTrigger)
        {
            if (hit.collider.CompareTag("ScoreLine"))
            {
                //Debug.Log("�浹");
                return 2;
            }
        }
        return 0;
    }

    private void OnTriggerStay(Collider other)
    {
        Fixed_TPC Fixed_TPC = GetComponent<Fixed_TPC>();
        if (other.CompareTag("G-Reverse"))
        {
            Debug.Log("�浹");
            Fixed_TPC.set_reversegravity();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Fixed_TPC Fixed_TPC = GetComponent<Fixed_TPC>();
        if (other.CompareTag("G-Reverse"))
        {
            Debug.Log("����");
            Fixed_TPC.set_normalgravity();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Fixed_TPC Fixed_TPC = GetComponent<Fixed_TPC>();
        if (other.CompareTag("ScoreLine"))
        {
            Debug.Log("���� �߰�");
        }
    }
}
