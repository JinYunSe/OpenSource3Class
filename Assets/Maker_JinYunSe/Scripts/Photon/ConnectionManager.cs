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
    public GameObject nickNameCanvas;   //닉네임 적기 캔버스

    public GameObject mainCanvas;   //메인 캔버스

    public GameObject createRoomCanvas; // 방 만들기 캔버스

    public GameObject passWard; // 비밀번호 관련 칸 

    public InputField roomName; // 방 이름 적는 칸
    public Toggle secrectCheck; // 비밀방 체크 여부
    public InputField inputPw;  // 비밀방 체크라면 비밀번호 입력 란

    public GameObject findRoomCanvas; // 방 찾기 캔버스
    private void Start()
    {
        secrectCheck.onValueChanged.AddListener(
            (bool bOn) =>
            {
                bool val = bOn; //누루는 이벤트 마다 값이 들어온다.
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
    /// 각각의 캔버스 띄우는 구간
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
    
    /// 방 만들기 및 방 만든 사람은 자동으로 방 참가
    public void OnCreateRoom()
    {
        Debug.Log("방 만들기 실행");
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 4; //무료 접속은 20명 까지 가능이라 
        ro.IsOpen = true; //룸을 열기
        ro.IsVisible = true; //로비에서 공개 여부
        PhotonNetwork.CreateRoom(roomName.text, ro);
    }

    /// 게임 종료 버튼 클릭 함수
    public void GameExit()
    {
        Application.Quit();
    }

}
