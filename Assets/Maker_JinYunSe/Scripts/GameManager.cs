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

public class GameManager : MonoBehaviour
{
    GameObject[] player;
    PhotonView[] photonView;
    void Start()
    {
        StartCoroutine(TimeOutEndGame());
    }

    public IEnumerator TimeOutEndGame()
    {
        yield return new WaitForSecondsRealtime(60);
        player = GameObject.FindGameObjectsWithTag("Player");
        photonView = new PhotonView[player.Length];
        for (int i = 0; i < player.Length; i++)
        {
            photonView[i] = player[i].GetPhotonView();
            string timetemp = player[i].transform.Find("StaticUI/TimerText").GetComponent<Text>().text;
            int time = int.Parse(Regex.Replace(timetemp, @"\D", string.Empty));
            Transform endGamePanel = player[i].transform.Find("EndGameCanvas/EndGameUI");
            endGamePanel.Find("TimeText").GetComponent<Text>().text = "Time : " + time;
            bool GetTailCheck =  player[i].transform.Find("Tails").gameObject.activeSelf;
            if (GetTailCheck) endGamePanel.Find("WinLoseText").GetComponent<Text>().text = "You Win!!";
            else endGamePanel.Find("WinLoseText").GetComponent<Text>().text = "You Lose...";
            if (photonView[i].IsMine) endGamePanel.parent.gameObject.SetActive(true);
        }
    }
}
