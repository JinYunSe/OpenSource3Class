using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ranking : MonoBehaviour
{
    private int playercount;
    
    private void Start()
    {
        playercount = -1;
    }

    private void Update()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("플레이어 수 : "+player.Length);
        playercount = player.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform endPanel = other.transform.Find("EndGameCanvas/EndGameUI");
        if (playercount == 1) endPanel.Find("WinLoseText").GetComponent<Text>().text = "You Win!!";
        else endPanel.Find("WinLoseText").GetComponent<Text>().text = "You Lose...";
        endPanel.parent.gameObject.transform.parent = transform;
        endPanel.parent.gameObject.SetActive(true);
        PhotonNetwork.Destroy(other.gameObject);
    }
}