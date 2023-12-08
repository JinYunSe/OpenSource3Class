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

        // 함수 파라미터 : 현재 위치, Box의 절반 사이즈, Ray의 방향, RaycastHit 결과, Box의 회전값, BoxCast를 진행할 거리
        if (Physics.BoxCast(transform.position, boxSize / 2.0f, -transform.up, out RaycastHit hit, transform.rotation, maxDistance, groundLayer))
        {
            // Hit된 지점까지 ray를 그려준다.
            Gizmos.DrawRay(transform.position, -transform.up * hit.distance);

            // Hit된 지점에 박스를 그려준다.
            Gizmos.DrawWireCube(transform.position + - transform.up * hit.distance, boxSize);
            //Debug.Log("충돌");
        }
        else
        {
            // Hit가 되지 않았으면 최대 검출 거리로 ray를 그려준다.
            Gizmos.DrawRay(transform.position, -transform.up * maxDistance);
        }

    }

    public int IsGrounded()
    {
        bool checker = Physics.BoxCast(transform.position, boxSize / 2.0f, -transform.up, out RaycastHit hit, transform.rotation, maxDistance, groundLayer);
        if (checker && hit.collider.CompareTag("JumpZone"))
        {
            Debug.Log("감지");
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
                //Debug.Log("충돌");
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
            Debug.Log("충돌");
            Fixed_TPC.set_reversegravity();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Fixed_TPC Fixed_TPC = GetComponent<Fixed_TPC>();
        if (other.CompareTag("G-Reverse"))
        {
            Debug.Log("멈춤");
            Fixed_TPC.set_normalgravity();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Fixed_TPC Fixed_TPC = GetComponent<Fixed_TPC>();
        if (other.CompareTag("ScoreLine"))
        {
            Debug.Log("점수 추가");
        }
    }
}
