using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScripts : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(OutGame());
    }

    IEnumerator OutGame()
    {
        yield return new WaitForSecondsRealtime(5);
        PhotonNetwork.LoadLevel("UI");
    }
}
