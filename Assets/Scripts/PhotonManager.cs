using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    //���� �Է�
    private readonly string version = "1.0f";
    [Header("������ ��� �׷�")]
    [SerializeField] private GameObject SpawnPointGroup;

    private void Awake()
    {
        Debug.Log("���� NickName : " + PhotonNetwork.NickName);
        // ���� ���� �����鿡�� �ڵ����� ���� �ε�
        PhotonNetwork.AutomaticallySyncScene = true;
        // ���� ������ �������� ���� ���
        // �ٸ� ������ ������ ��� �ٸ� ���𰡰� ���� ���
        // ���� �߻��� �� �� �ֱ� ������ ���� ������ ���������� ����

        PhotonNetwork.GameVersion = version;
        // ���� ������ ��� Ƚ�� ����. �ʴ� 30ȸ
        Debug.Log(PhotonNetwork.SendRate);

        //���� ����
        PhotonNetwork.ConnectUsingSettings();
    }

    // ���� ������ ���� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master!");
        Debug.Log($"PhotonNetwork.InLobby = { PhotonNetwork.InLobby}"); //�κ� ���� ���̶� False;
        PhotonNetwork.JoinLobby(); //�κ� ����
        //base.OnConnectedToMaster();
    }

    // �κ� ���� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinedLobby()
    {
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}"); //�κ� ���� �Ķ� True;
        PhotonNetwork.JoinRandomRoom(); // ���� ��ġ����ŷ ��� ����
        //base.OnJoinedLobby();
    }

    // ������ �� ������ ���� ���� ��� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinRandomFailed(short returnCode, string message)
    //                                   � ���� ���� Ȯ�� �뵵
    //                                                          �޽��� ���
    {
        Debug.Log($"JoinRandom Filed {returnCode} : {message}");

        // ���� �Ӽ� ����
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20; //���� ������ 20�� ���� �����̶� 
        ro.IsOpen = true; //���� ����
        ro.IsVisible = true; //�κ񿡼� ���� ����

        // �� ����
        PhotonNetwork.CreateRoom("My Room", ro);
        //base.OnJoinRandomFailed(returnCode, message);
    }

    // �� ������ �Ϸ�� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnCreatedRoom()
    {
        Debug.Log("Create Room");
        // �� �̸�
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
        //base.OnCreatedRoom();
    }

    // �뿡 ������ �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinedRoom()
    {
        //���� �� �̸�
        Debug.Log($"PhotonNetwork.InRoom = {PhotonNetwork.InRoom}");
        
        // ���� ������ ��
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");

        // �뿡 ������ ����� ���� Ȯ��
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            Debug.Log($"{player.Value.NickName}, {player.Value.ActorNumber}");
        }

        // ĳ���� ���� ������ �迭�� ����
        Transform[] points = SpawnPointGroup.GetComponentsInChildren<Transform>();
        Debug.Log($"������ �߰� Ȯ�� : {points.Length}");
        int idx = Random.Range(1, points.Length);

        // ĳ���� ����
        PhotonNetwork.Instantiate("Character", points[idx].position, points[idx].rotation, 0);
    }
}
