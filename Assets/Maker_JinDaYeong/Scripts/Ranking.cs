using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ranking : MonoBehaviour, IPunObservable
{
    private TextMeshProUGUI rankText;
    private Dictionary<string, int> playerScores = new Dictionary<string, int>();
    private int count = 1;

    void Start()
    {
        rankText = GameObject.Find("Rank").GetComponent<TextMeshProUGUI>();
        StartCoroutine(InitializePlayerScores());
    }

    private IEnumerator InitializePlayerScores()
    {
        yield return null;

        Debug.Log(PhotonNetwork.CurrentRoom.Players.Count + "명");

        //플레이어 점수 초기값 설정
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            string playerName = player.Value.NickName;
            Debug.Log(playerName + "입니다.");
            playerScores[playerName] = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.GetPhotonView().Controller.NickName;
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            string playerName = player.Value.NickName;
            if (name.Equals(playerName))
            {
                UpdatePlayerScore(playerName);
                rankText.text = "GameOver\nYour Score: " + playerScores[playerName];
                count++;
                PhotonNetwork.Destroy(other.gameObject);
            }

        }

    }

    private void UpdatePlayerScore(string playerName)
    {
        playerScores[playerName] = count * 10;
        Debug.Log(playerName + " : " + playerScores[playerName] + "획득");

    }

    private IEnumerator OutGame()
    {
        yield return new WaitForSecondsRealtime(5);
        PhotonNetwork.LoadLevel("UI");
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(playerScores);
            stream.SendNext(count);
        }
        else
        {
            playerScores = (Dictionary<string, int>)stream.ReceiveNext();
            count = (int)stream.ReceiveNext();
        }
    }
}