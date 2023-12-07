using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    [SerializeField]
    float time = 0.5f;

    public void OnTheFloor()
    {
        Invoke("Disappear", time);
    }

    void Disappear()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
