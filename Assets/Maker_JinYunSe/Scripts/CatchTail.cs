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
        //�ٸ� �ݶ��̴��� �浹�� ���ϱ� ���� ����
        if (other.CompareTag("Player") && other.gameObject.transform.Find("Tails").gameObject.activeSelf)
        {
            //���� ���� �׷��� �κ� ��Ȱ��ȭ
            other.transform.Find("Tails").gameObject.SetActive(false);
            //���� ���� �ݶ��̴� ������ �ִ� �κ� ��Ȱ��ȭ
            other.transform.Find("root/pelvis/Tail").gameObject.SetActive(false);

            other.transform.Find("Headparts/Crown").gameObject.SetActive(false);

            //���� �׷��� �κ� Ȱ��ȭ
            Grapic.SetActive(true);

            //������ �ݶ��̴� ������ �ִ� �κ� Ȱ��ȭ
            TailModel.SetActive(true);
            
            //�հ� ������Ʈ Ȱ��ȭ
            Crown.SetActive(true);
        }
    }
}
