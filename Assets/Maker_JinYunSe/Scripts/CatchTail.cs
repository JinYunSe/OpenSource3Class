using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTail : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("��ġ Ȯ��");
        if (other.gameObject.layer.Equals("Character"))
        {
            Debug.Log("��ġ Ȯ��");
            /*//���� ���� �׷��� �κ� ��Ȱ��ȭ
            other.gameObject.transform.parent.parent.parent.Find("Tails").gameObject.SetActive(false);
            //���� ���� �ݶ��̴� ������ �ִ� �κ� ��Ȱ��ȭ
            other.gameObject.transform.parent.gameObject.SetActive(false);
            
            //���� �׷��� �κ� Ȱ��ȭ
            gameObject.transform.Find("Tails").gameObject.SetActive(true);

            //������ �ݶ��̴� ������ �ִ� �κ� Ȱ��ȭ
            gameObject.transform.Find("root/pelvis/Tail").gameObject.SetActive(true);*/
        }
    }
}
