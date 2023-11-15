using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    public Text IDtext;
    public Button connetBtn;
    public GameObject nickNameCanvas;
    public GameObject mainCanvas;
    public GameObject createRoom;
    public GameObject findRoom;
    public void Connect()
    {
        if (IDtext.text == string.Empty) return;
        IDtext.text.Replace(" ", string.Empty);
        foreach (var player in PhotonNetwork.PlayerList)
        {
            if (IDtext.text.Equals(player.NickName))
            {
                IDtext.text = string.Empty;
                return;
            }
        }
        PhotonNetwork.LocalPlayer.NickName = IDtext.text;
        nickNameCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
    public void CreateRoom()
    {
        mainCanvas.SetActive(false);
        createRoom.SetActive(true);
    }

    public void BackCreateRoom()
    {
        mainCanvas.SetActive(true);
        createRoom.SetActive(false);
    }

    public void FindRoot()
    {
        mainCanvas.SetActive(false);
        findRoom.SetActive(true);
    }
    public void BackFindRoot()
    {
        mainCanvas.SetActive(true);
        findRoom.SetActive(false);
    }

    public void GameExit() 
    {
        Application.Quit();
    }
}
