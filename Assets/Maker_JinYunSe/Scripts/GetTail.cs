using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTail : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("hand_l") || other.gameObject.name.Equals("hand_r")) return;
        // 다른 콜라이더와 충돌을 회피하기 위해서 사용

        if (other.CompareTag("Player"))
        {

            Destroy(gameObject.transform.parent.parent.gameObject);

            //꼬리 그래픽 부분 활성화
            other.gameObject.transform.Find("Tails").gameObject.SetActive(true);

            //꼬리의 콜라이더 정보가 있는 부분 활성화
            other.gameObject.transform.Find("root/pelvis/Tail").gameObject.SetActive(true);

            other.gameObject.transform.Find("Headparts/Crown").gameObject.SetActive(true);
        }
    }
}
