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
        roomOptions.MaxPlayers = 4; //무료 접속은 4명 까지 가능이라 
        roomOptions.IsOpen = true; //룸을 열기
        roomOptions.IsVisible = true; //로비에서 공개 여부
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
