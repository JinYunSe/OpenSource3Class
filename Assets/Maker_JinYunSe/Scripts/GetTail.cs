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
        // �ٸ� �ݶ��̴��� �浹�� ȸ���ϱ� ���ؼ� ���

        if (other.CompareTag("Player"))
        {

            Destroy(gameObject.transform.parent.parent.gameObject);

            //���� �׷��� �κ� Ȱ��ȭ
            other.gameObject.transform.Find("Tails").gameObject.SetActive(true);

            //������ �ݶ��̴� ������ �ִ� �κ� Ȱ��ȭ
            other.gameObject.transform.Find("root/pelvis/Tail").gameObject.SetActive(true);

            other.gameObject.transform.Find("Headparts/Crown").gameObject.SetActive(true);
        }
    }
}
