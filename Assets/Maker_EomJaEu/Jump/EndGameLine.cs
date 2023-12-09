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
        Transform endPanel = other.transform.Find("EndGameCanvas/EndGameUI");
        if (playercount == 1) endPanel.Find("WinLoseText").GetComponent<Text>().text = "You Win!!";
        else endPanel.Find("WinLoseText").GetComponent<Text>().text = "You Lose...";
        endPanel.parent.gameObject.SetActive(true);
        PhotonNetwork.Destroy(gameObject);
    }
}
