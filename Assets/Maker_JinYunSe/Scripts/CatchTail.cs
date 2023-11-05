using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTail : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("터치 확인");
        if (other.gameObject.layer.Equals("Character"))
        {
            Debug.Log("터치 확인");
            /*//상대방 꼬리 그래픽 부분 비활성화
            other.gameObject.transform.parent.parent.parent.Find("Tails").gameObject.SetActive(false);
            //상대방 꼬리 콜라이더 정보가 있는 부분 비활성화
            other.gameObject.transform.parent.gameObject.SetActive(false);
            
            //꼬리 그래픽 부분 활성화
            gameObject.transform.Find("Tails").gameObject.SetActive(true);

            //꼬리의 콜라이더 정보가 있는 부분 활성화
            gameObject.transform.Find("root/pelvis/Tail").gameObject.SetActive(true);*/
        }
    }
}
