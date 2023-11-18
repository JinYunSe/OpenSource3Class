using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;

    private RoomsCanvaes _roomCanvas;

    public void FirstInitialize(RoomsCanvaes canvases)
    {
        _roomCanvas = canvases;
    }

    public void OnClick_CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4; //���� ������ 4�� ���� �����̶� 
        roomOptions.IsOpen = true; //���� ����
        roomOptions.IsVisible = true; //�κ񿡼� ���� ����
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, roomOptions, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Create Room Successfully", this);
        _roomCanvas.CurrentRoomCanvas.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creation failed : "+message, this);
        
    }
}
