using Photon.Pun;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailingFloorEndGameScripts : MonoBehaviour
{
    // Start is called before the first frame update
    int playercount = -1;
    bool check = true;
    private void Update()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        playercount = player.Length;
        Debug.Log("유저확인 : " + playercount);
        if (playercount == 0 && check)
        {
            check = false;
            StartCoroutine(OutGame());
        }
    }  
    IEnumerator OutGame()
    {
        yield return new WaitForSecondsRealtime(5);
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("UI");
            Debug.Log("동작 확인");
        }
    }
}
