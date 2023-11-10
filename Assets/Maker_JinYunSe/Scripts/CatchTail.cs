using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTail : MonoBehaviour
{
    public GameObject Grapic;
    public GameObject TailModel;
    public GameObject Crown;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("hand_l") || other.gameObject.name.Equals("hand_r")) return;
        //다른 콜라이더와 충돌을 피하기 위해 생성
        if (other.CompareTag("Player") && other.gameObject.transform.Find("Tails").gameObject.activeSelf)
        {
            //상대방 꼬리 그래픽 부분 비활성화
            other.transform.Find("Tails").gameObject.SetActive(false);
            //상대방 꼬리 콜라이더 정보가 있는 부분 비활성화
            other.transform.Find("root/pelvis/Tail").gameObject.SetActive(false);

            other.transform.Find("Headparts/Crown").gameObject.SetActive(false);

            //꼬리 그래픽 부분 활성화
            Grapic.SetActive(true);

            //꼬리의 콜라이더 정보가 있는 부분 활성화
            TailModel.SetActive(true);
            
            //왕관 오브젝트 활성화
            Crown.SetActive(true);
        }
    }
}
