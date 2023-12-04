using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;

public class JinDaYeongPhotonManager : MonoBehaviourPunCallbacks
{
    [Header("리스폰 장소 그룹")]
    [SerializeField] private GameObject SpawnPointGroup;
    MyGizmo[] points;
    int index = -1;

    void Start()
    {
        points = SpawnPointGroup.GetComponentsInChildren<MyGizmo>();
        StartCoroutine(SpwanPlayer());
    }

    public IEnumerator SpwanPlayer()
    {
        yield return null;
        Debug.Log("인원 확인 : " + PhotonNetwork.CurrentRoom.PlayerCount);
        index = PhotonNetwork.LocalPlayer.ActorNumber - 1;
        PhotonNetwork.Instantiate("JinDaYeongCharacter", points[index].transform.position, points[index].transform.rotation, 0);
    }
}
