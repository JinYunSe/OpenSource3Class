using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTail : MonoBehaviour
{
    public Transform topTrans;
    private void Start()
    {
        topTrans = transform.root;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("hand_l") || other.gameObject.name.Equals("hand_r")) return;
        //다른 콜라이더와 충돌을 피하기 위해 생성
        if (other.CompareTag("Player") && other.gameObject.transform.Find("Tails").gameObject.activeSelf)
        {
            Debug.Log("뺐긴 사람"+other.gameObject.GetPhotonView().Controller.NickName);
            //상대방 꼬리 그래픽 부분 비활성화
            other.transform.Find("Tails").gameObject.SetActive(false);
            //상대방 꼬리 콜라이더 정보가 있는 부분 비활성화
            other.transform.Find("root/pelvis/Tail").gameObject.SetActive(false);

            other.transform.Find("Headparts/Crown").gameObject.SetActive(false);

            Debug.Log("뺐은 사람" + topTrans.gameObject.GetPhotonView().Controller.NickName);
            //꼬리 그래픽 부분 활성화
            topTrans.Find("Tails").gameObject.SetActive(true);

            //꼬리의 콜라이더 정보가 있는 부분 활성화
            topTrans.Find("root/pelvis/Tail").gameObject.SetActive(true);

            //왕관 오브젝트 활성화
            topTrans.Find("Headparts/Crown").gameObject.SetActive(true);
        }
    }
}
