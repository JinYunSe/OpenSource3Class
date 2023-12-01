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
    class Ranking
    {
        private string nickName;
        private int time;
        private int ranking;
        public Ranking(string nickName, int time)
        {
            this.nickName = nickName;
            this.time = time;
            ranking = 1;
        }
        public string GetNickName()
        {
            return nickName;
        }
        public int GetTime()
        {
            return time;
        }
        public void SetRanking()
        {
            ranking++;
        }
        public int GetRanking()
        {
            return ranking;
        }
    }

    List<Ranking> Rankings;
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
        Rankings = new List<Ranking>();
        for (int i = 0; i < player.Length; i++)
        {
            photonView[i] = player[i].GetPhotonView();
            string nickName = photonView[i].Controller.NickName;
            string timetemp = player[i].transform.Find("StaticUI/TimerText").GetComponent<Text>().text;
            int time = int.Parse(Regex.Replace(timetemp, @"\D", string.Empty));
            Rankings.Add(new Ranking(nickName, time));
        }
        Rank();
    }
    public void Rank()
    {
        for (int i = 0; i < Rankings.Count; i++)
        {
            for (int j = i + 1; j < Rankings.Count; j++)
            {
                if (Rankings[i].GetTime() > Rankings[j].GetTime())
                {
                    Rankings[j].SetRanking();
                }
            }
        }
        RankView();
    }

    private void RankView()
    {
        for (int i = 0; i < player.Length; i++)
        {
            Transform endGamePanel = player[i].transform.Find("EndGameCanvas/EndGameUI");
            endGamePanel.Find("TimeText").GetComponent<Text>().text = "Time : " + Rankings[i].GetTime();
            endGamePanel.Find("RankingText").GetComponent<Text>().text = "Ranking : " + Rankings[i].GetRanking();
            if (photonView[i].IsMine) endGamePanel.parent.gameObject.SetActive(true);
            Debug.Log("Nick Name : " + photonView[i].Controller.NickName + " Time : " + Rankings[i].GetTime() + " Rank : " + Rankings[i].GetRanking());
        }
    }
}
