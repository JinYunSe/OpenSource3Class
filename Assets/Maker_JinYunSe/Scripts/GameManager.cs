using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject[] player;
    PhotonView[] photonView;
    bool timeOut = false;
    int timer = 60; 
    void Start()
    {
        StartCoroutine(UserFind());
        StartCoroutine(TimerStart());
        StartCoroutine(TimeOutEndGame());
    }
    public IEnumerator UserFind()
    {
        yield return null;
        player = GameObject.FindGameObjectsWithTag("Player");
        photonView = new PhotonView[player.Length];
        for(int i = 0; i < photonView.Length; i++)
        {
            photonView[i] = player[i].GetPhotonView();
            if (photonView[i].IsMine) player[i].transform.Find("StaticUI").gameObject.SetActive(true);
        }
    }

    public IEnumerator TimerStart()
    {
        do
        {
            yield return new WaitForSecondsRealtime(1);
            timer -= 1;
            for (int i = 0; i < player.Length; i++)
            {
                if (photonView[i].IsMine)
                {
                    Text TimerText = player[i].transform.Find("StaticUI/RemainTimeText").GetComponent<Text>();
                    TimerText.text = "Remain Time : " + timer; 
                    if (10 < timer && timer <= 30)
                    {
                        TimerText.color = Color.yellow;
                    }
                    else if (timer <= 10)
                    {
                        TimerText.color = Color.red;
                    }
                }
            }
            if (timer == 0) timeOut = true;
        }while(!timeOut);
    }

    public IEnumerator TimeOutEndGame()
    {
        yield return new WaitUntil(()=>(timeOut == true));
        for (int i = 0; i < player.Length; i++)
        {
            photonView[i] = player[i].GetPhotonView();
            Transform endGamePanel = player[i].transform.Find("EndGameCanvas/EndGameUI");
            bool GetTailCheck = player[i].transform.Find("Tails").gameObject.activeSelf;
            if (GetTailCheck) endGamePanel.Find("WinLoseText").GetComponent<Text>().text = "You Win!!";
            else endGamePanel.Find("WinLoseText").GetComponent<Text>().text = "You Lose...";
            if (photonView[i].IsMine) endGamePanel.parent.gameObject.SetActive(true);
        }
    }
}
