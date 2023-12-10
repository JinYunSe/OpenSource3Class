using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class EndGameMananger : MonoBehaviour
{
    GameObject[] player;
    PhotonView[] photonView;
    bool timeOut = false;
    int timer = 60;
    int winer_index = -1;
    void Start()
    {
        StartCoroutine(UserFind());
        StartCoroutine(TimerStart());
        StartCoroutine(WinnerFInd());
    }
    private IEnumerator UserFind()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("유저 찾기 시작");
        player = GameObject.FindGameObjectsWithTag("Player");
        photonView = new PhotonView[player.Length];
        for (int i = 0; i < photonView.Length; i++)
        {
            photonView[i] = player[i].GetPhotonView();
            if (photonView[i].IsMine) player[i].transform.Find("StaticUI").gameObject.SetActive(true);
        }
        Debug.Log("player count" + player.Length);
    }

    private IEnumerator TimerStart()
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
        } while (!timeOut);
    }
    private IEnumerator WinnerFInd() 
    {
        yield return new WaitUntil(() => (timeOut == true));
        for(int i = 0; i < player.Length - 1; i++)
        {
            for(int j = i + 1; j < player.Length; j++)
            {
                string score1_temp = player[i].transform.Find("StaticUI/ScoreText").GetComponent<Text>().text;
                string score2_temp = player[j].transform.Find("StaticUI/ScoreText").GetComponent<Text>().text;
                int score1 = int.Parse(Regex.Replace(score1_temp, @"\D", string.Empty));
                int score2 = int.Parse(Regex.Replace(score2_temp, @"\D", string.Empty));
                if (score1 > score2)
                {
                    winer_index = i;
                }
                else
                {
                    winer_index = j;
                }
            }
        }
        StartCoroutine(TimeOutEndGame());
    }
    private IEnumerator TimeOutEndGame()
    {
        yield return null;
        for (int i = 0; i < player.Length; i++)
        {
            photonView[i] = player[i].GetPhotonView();
            Transform endGamePanel = player[i].transform.Find("EndGameCanvas/EndGameUI");
            if (winer_index == i) endGamePanel.Find("WinLoseText").GetComponent<Text>().text = "You Win!!";
            else endGamePanel.Find("WinLoseText").GetComponent<Text>().text = "You Lose...";
            if (photonView[i].IsMine) endGamePanel.parent.gameObject.SetActive(true);
        }
    }
}
