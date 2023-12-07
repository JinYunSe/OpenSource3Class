using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class JumpGameManager : MonoBehaviour
{
    private int playercount;
    private GameObject[] player;

    void Start()
    {
        playercount = -1;
    }

    private void Update()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    void EndGame(GameObject winner)
    {
        Time.timeScale = 0;
        playercount = player.Length;
        for (int i = 0; i < player.Length; i++)
        {
            if (player[i] == winner)
            {
                
                //¼öÁ¤
            }
        }
    }
}
