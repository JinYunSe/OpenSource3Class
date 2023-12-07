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
    Stopwatch watch = new Stopwatch();
    bool timeOut = false;
    float timer = 3600; 
    void Start()
    {
        StartCoroutine(UserFind());
        watch.Start();
        StartCoroutine(TimeOutEndGame());
    }

    public IEnumerator UserFind()
    {
        yield return null;
        player = GameObject.FindGameObjectsWithTag("Player");
        photonView = new PhotonView[player.Length];
    }

    public IEnumerator TimeOutEndGame()
    {
        yield return new WaitUntil(()=>(timeOut == true));
        for (int i = 0; i < player.Length; i++)
        {
            photonView[i] = player[i].GetPhotonView();
            string timetemp = player[i].transform.Find("StaticUI/TimerText").GetComponent<Text>().text;
            int time = int.Parse(Regex.Replace(timetemp, @"\D", string.Empty));
            Transform endGamePanel = player[i].transform.Find("EndGameCanvas/EndGameUI");
            endGamePanel.Find("TimeText").GetComponent<Text>().text = "Time : " + time;
            bool GetTailCheck = player[i].transform.Find("Tails").gameObject.activeSelf;
            if (GetTailCheck) endGamePanel.Find("WinLoseText").GetComponent<Text>().text = "You Win!!";
            else endGamePanel.Find("WinLoseText").GetComponent<Text>().text = "You Lose...";
            if (photonView[i].IsMine) endGamePanel.parent.gameObject.SetActive(true);
        }
    }
}
