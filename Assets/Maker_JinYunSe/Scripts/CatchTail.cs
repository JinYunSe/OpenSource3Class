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
            Debug.Log("���� ��ġ Ȯ��");
            //���� �ֻ��� �θ� ������Ʈ
            Transform TopParent = other.gameObject.transform.parent;
            //���� ���� �׷��� �κ� ��Ȱ��ȭ
            TopParent.Find("Tails").gameObject.SetActive(false);
            //���� ���� �ݶ��̴� ������ �ִ� �κ� ��Ȱ��ȭ
            TopParent.Find("root/pelvis/Tail").gameObject.SetActive(false);

            TopParent.Find("Headparts/Crown").gameObject.SetActive(false);

            //���� �׷��� �κ� Ȱ��ȭ
            Grapic.SetActive(true);

            //������ �ݶ��̴� ������ �ִ� �κ� Ȱ��ȭ
            TailModel.SetActive(true);
            
            //�հ� ������Ʈ Ȱ��ȭ
            Crown.SetActive(true);
        }
    }
}
