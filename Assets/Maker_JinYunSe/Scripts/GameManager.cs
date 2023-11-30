using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
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
    void Start()
    {
        StartCoroutine(TimeOutEndGame());
    }

    public IEnumerator TimeOutEndGame()
    {
        yield return new WaitForSecondsRealtime(20);
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("player count: "+player.Length);
        Rankings = new List<Ranking>();
        for (int i  = 0; i < player.Length; i++)
        {
            name =  player[i].GetPhotonView().Controller.NickName;
            string timetemp = player[i].transform.Find("StaticUI/TimerText").GetComponent<Text>().text;
            int time = int.Parse(Regex.Replace(timetemp, @"\D", string.Empty));
            Rankings.Add(new Ranking(name, time));
        }
        for (int i = 0; i < player.Length; i++)
        {
            Debug.Log("Nick : " + Rankings[i].GetNickName() + ", time : " + Rankings[i].GetTime() + ", Ranking : " + Rankings[i].GetRanking());
        }
    }
    public void Rank()
    {
    }
}
