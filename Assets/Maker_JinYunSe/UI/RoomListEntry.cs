using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Asteroids
{
    public class RoomListEntry : MonoBehaviour
    {
        public Text RoomNameText;
        public Text GameNameText;
        public Text RoomPlayersText;
        public Button JoinRoomButton;
        private string roomName;

        public void Start()
        {
            JoinRoomButton.onClick.AddListener(() =>
            {
                if (PhotonNetwork.InLobby)
                {
                    PhotonNetwork.LeaveLobby();
                }
                Debug.Log("roomName : " + roomName);
                PhotonNetwork.JoinRoom(roomName);
            });
        }

        public void Initialize(string RoomName,string GameName,byte currentPlayers, byte maxPlayers)
        {
            roomName = RoomName+"\n"+GameName;
            RoomNameText.text = RoomName;
            GameNameText.text = GameName;
            RoomPlayersText.text = currentPlayers + " / " + maxPlayers;
        }
    }
}