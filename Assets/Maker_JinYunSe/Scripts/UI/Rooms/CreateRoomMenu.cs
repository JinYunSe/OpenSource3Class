using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using System.Linq;
using System.Text.RegularExpressions;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;
    [SerializeField]
    private InputField _roomNameInputField;

    [SerializeField]
    private Text _InRoomName;

    private RoomsCanvaes _roomCanvas;

    public void FirstInitialize(RoomsCanvaes canvases)
    {
        _roomCanvas = canvases;
    }

    public void OnClick_CreateRoom()
    {
        string temp = _roomName.text;
        temp = Regex.Replace(temp, @"[^a-zA-Z]", string.Empty);
        _roomNameInputField.text = string.Empty;
        if (temp.Equals(string.Empty)) return;
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4; //무료 접속은 4명 까지 가능이라
        PhotonNetwork.JoinOrCreateRoom(temp, roomOptions, TypedLobby.Default);
        _InRoomName.text = temp;
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
