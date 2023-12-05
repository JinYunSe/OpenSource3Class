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

        Debug.Log(PhotonNetwork.CurrentRoom.Players.Count + "��");

        //�÷��̾� ���� �ʱⰪ ����
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            string playerName = player.Value.NickName;
            Debug.Log(playerName + "�Դϴ�.");
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
        Debug.Log(playerName + " : " + playerScores[playerName] + "ȹ��");

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