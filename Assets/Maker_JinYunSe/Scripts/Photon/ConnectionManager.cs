using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    public Text IDtext;
    public Button connetBtn;
    public GameObject nickNameCanvas;   //�г��� ���� ĵ����

    public GameObject mainCanvas;   //���� ĵ����

    public GameObject createRoomCanvas; // �� ����� ĵ����

    public GameObject passWard; // ��й�ȣ ���� ĭ 

    public InputField roomName; // �� �̸� ���� ĭ
    public Toggle secrectCheck; // ��й� üũ ����
    public InputField inputPw;  // ��й� üũ��� ��й�ȣ �Է� ��

    public GameObject findRoomCanvas; // �� ã�� ĵ����
    private void Start()
    {
        secrectCheck.onValueChanged.AddListener(
            (bool bOn) =>
            {
                bool val = bOn; //����� �̺�Ʈ ���� ���� ���´�.
                passWard.SetActive(val);
                if (!val) inputPw.text = string.Empty;
            }
        );
    }
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
        Debug.Log("Connecting to Server");
        MasterManager.GameSettings.NickName = IDtext.text;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.ConnectUsingSettings();
        nickNameCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connted to Server");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from Server for reason : " + cause.ToString());
        //DisconnectCause.
    }
    /// ������ ĵ���� ���� ����
    public void CreateRoomCanvas()
    {
        mainCanvas.SetActive(false);
        createRoomCanvas.SetActive(true);
    }

    public void BackCreateRoomCanvas()
    {
        mainCanvas.SetActive(true);
        createRoomCanvas.SetActive(false);
        secrectCheck.isOn = false;
        passWard.SetActive(false);
        roomName.text = string.Empty;
        inputPw.text = string.Empty;
    }

    public void FindRoomCanvas()
    {
        mainCanvas.SetActive(false);
        findRoomCanvas.SetActive(true);
    }
    public void BackFindRoomCanvas()
    {
        mainCanvas.SetActive(true);
        findRoomCanvas.SetActive(false);
    }
    ///////////////////////////////////
    
    /// �� ����� �� �� ���� ����� �ڵ����� �� ����
    public void OnCreateRoom()
    {
        Debug.Log("�� ����� ����");
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 4; //���� ������ 20�� ���� �����̶� 
        ro.IsOpen = true; //���� ����
        ro.IsVisible = true; //�κ񿡼� ���� ����
        PhotonNetwork.CreateRoom(roomName.text, ro);
    }

    /// ���� ���� ��ư Ŭ�� �Լ�
    public void GameExit()
    {
        Application.Quit();
    }

}
