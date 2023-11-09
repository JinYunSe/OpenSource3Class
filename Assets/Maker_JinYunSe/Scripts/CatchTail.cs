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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tail"))
        {
            Debug.Log("꼬리 터치 확인");
            //가장 최상위 부모 오브젝트
            Transform TopParent = other.gameObject.transform.parent;
            //상대방 꼬리 그래픽 부분 비활성화
            TopParent.Find("Tails").gameObject.SetActive(false);
            //상대방 꼬리 콜라이더 정보가 있는 부분 비활성화
            TopParent.Find("root/pelvis/Tail").gameObject.SetActive(false);

            TopParent.Find("Headparts/Crown").gameObject.SetActive(false);

            //꼬리 그래픽 부분 활성화
            Grapic.SetActive(true);

            //꼬리의 콜라이더 정보가 있는 부분 활성화
            TailModel.SetActive(true);
            
            //왕관 오브젝트 활성화
            Crown.SetActive(true);
        }
    }
}
