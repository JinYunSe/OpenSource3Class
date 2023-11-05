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
        foreach (var Player in PhotonNetwork.CurrentRoom.Players)
        {
            if(Player.Value.NickName.Equals(PhotonNetwork.NickName) && other.CompareTag("Player"))
            {
                Debug.Log("Player Nick Name : " + PhotonNetwork.NickName + "Player.Value.NickName : "+ Player.Value.NickName);
                Destroy(gameObject.transform.parent.parent.gameObject);
                
                //꼬리 그래픽 부분 활성화
                other.gameObject.transform.Find("Tails").gameObject.SetActive(true);

                //꼬리의 콜라이더 정보가 있는 부분 활성화
                other.gameObject.transform.Find("root/pelvis/Tail").gameObject.SetActive(true);

                other.gameObject.transform.Find("Headparts/Crown").gameObject.SetActive(true);
            }
        }
    }
}
