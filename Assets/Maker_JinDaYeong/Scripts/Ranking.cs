using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour, IPunObservable
{
    private Dictionary<string, int> playerScores = new Dictionary<string, int>();
    private int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        // ���� ���� �� �÷��̾���� ���� �ʱ�ȭ
        //InitializePlayerScores();
        StartCoroutine(InitializePlayerScores());
    }

    private IEnumerator InitializePlayerScores()
    {
        yield return new WaitForSecondsRealtime(5f); 

        Debug.Log(PhotonNetwork.CurrentRoom.Players.Count+"��");

        // �÷��̾� ���� �ʱⰪ ����
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            string playerName = player.Value.NickName;
            Debug.Log(playerName + " �Դϴ�");
            playerScores[playerName] = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.GetPhotonView().Controller.NickName;
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            string playerName = player.Value.NickName;
            if(name.Equals(playerName))
            {
                UpdatePlayerScore(playerName);
                count++;
                PhotonNetwork.Destroy(other.gameObject);
            }
        }
    }
    private void UpdatePlayerScore(string playerName)
    {
        playerScores[playerName] =  count * 10;
        Debug.Log(playerName + " : " + playerScores[playerName] + "ȹ��");
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) stream.SendNext(playerScores);
        else playerScores = (Dictionary<string,int>)stream.ReceiveNext();
    }
}
