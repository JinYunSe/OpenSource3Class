using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameLine : MonoBehaviour
{
    private int playercount;
    private GameObject[] player;
    private PhotonView[] photonView;
    void Start()
    {
        StartCoroutine(FindUser());
        playercount = -1;
    }

    IEnumerator FindUser()
    {
        yield return new WaitForSeconds(1f);
        player = GameObject.FindGameObjectsWithTag("Player");
        playercount = player.Length;
        Debug.Log("»ç¶÷ ¼ö : " + playercount);
        photonView = new PhotonView[playercount];
        for (int i = 0; i < photonView.Length; i++)
        {
            photonView[i] = player[i].GetPhotonView();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.Destroy(gameObject);
        string name = other.gameObject.GetPhotonView().Controller.NickName;
        for(int i = 0; i <  playercount; i++)
        {
            Transform otherPersonEndPanel = player[i].transform.Find("EndGameCanvas/EndGameUI");
            if (player[i].GetPhotonView().Controller.NickName.Equals(name))
            {
                otherPersonEndPanel.Find("WinLoseText").GetComponent<Text>().text = "You Win!!";
            }
            else otherPersonEndPanel.Find("WinLoseText").GetComponent<Text>().text = "You Lose...";
            if (photonView[i].IsMine) otherPersonEndPanel.parent.gameObject.SetActive(true);
        }
    }
}
