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
        //�ٸ� �ݶ��̴��� �浹�� ���ϱ� ���� ����
        if (other.CompareTag("Player") && other.gameObject.transform.Find("Tails").gameObject.activeSelf)
        {
            Debug.Log("���� ���"+other.gameObject.GetPhotonView().Controller.NickName);
            //���� ���� �׷��� �κ� ��Ȱ��ȭ
            other.transform.Find("Tails").gameObject.SetActive(false);
            //���� ���� �ݶ��̴� ������ �ִ� �κ� ��Ȱ��ȭ
            other.transform.Find("root/pelvis/Tail").gameObject.SetActive(false);

            other.transform.Find("Headparts/Crown").gameObject.SetActive(false);

            Debug.Log("���� ���" + topTrans.gameObject.GetPhotonView().Controller.NickName);
            //���� �׷��� �κ� Ȱ��ȭ
            topTrans.Find("Tails").gameObject.SetActive(true);

            //������ �ݶ��̴� ������ �ִ� �κ� Ȱ��ȭ
            topTrans.Find("root/pelvis/Tail").gameObject.SetActive(true);

            //�հ� ������Ʈ Ȱ��ȭ
            topTrans.Find("Headparts/Crown").gameObject.SetActive(true);
        }
    }
}
