using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndLineScripts : MonoBehaviour
{
    private int playercount;
    private GameObject[] player;
    private PhotonView[] photonViews;
    void Start()
    {
        StartCoroutine(FindUser());
        playercount = -1;
    }

    IEnumerator FindUser()
    {
        yield return null;
        player = GameObject.FindGameObjectsWithTag("Player");
        playercount = player.Length;
        photonViews = new PhotonView[playercount];
    }

    private void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.Destroy(gameObject);
        for (int i = 0; i < player.Length; i++)
        {
            if (photonViews[i].IsMine)
            {
                Transform endPanel = player[i].transform.Find("EndGameCanvas/EndGameUI");
                endPanel.Find("WinLoseText").GetComponent<Text>().text = "You Win!!";
                endPanel.parent.gameObject.SetActive(true);
                endPanel.parent.gameObject.transform.parent = transform;
            }
            else
            {
                Transform endPanel = player[i].transform.Find("EndGameCanvas/EndGameUI");
                endPanel.Find("WinLoseText").GetComponent<Text>().text = "You Lose...";
                endPanel.parent.gameObject.SetActive(true);
                endPanel.parent.gameObject.transform.parent = transform;
            }
        }
    }
}
