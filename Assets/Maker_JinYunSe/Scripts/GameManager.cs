using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeOutEndGame());
    }

    public IEnumerator TimeOutEndGame()
    {
        yield return new WaitForSecondsRealtime(60);
        Debug.Log("»Æ¿Œ");
    } 
}
