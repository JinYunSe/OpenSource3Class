using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    //버전 입력
    private readonly string version = "1.0f";
    [Header("리스폰 장소 그룹")]
    [SerializeField] private GameObject SpawnPointGroup;

    private void Awake()
    {
        Debug.Log("유저 NickName : " + PhotonNetwork.NickName);
        // 같은 룸의 유저들에게 자동으로 씬을 로딩
        PhotonNetwork.AutomaticallySyncScene = true;
        // 같은 버전의 유저끼리 접속 허용
        // 다른 버전이 존재할 경우 다른 무언가가 있을 경우
        // 오류 발생이 될 수 있기 때문에 같은 버전의 유저끼리만 입장

        PhotonNetwork.GameVersion = version;
        // 포톤 서버와 통신 횟수 설정. 초당 30회
        Debug.Log(PhotonNetwork.SendRate);

        //서버 접속
        PhotonNetwork.ConnectUsingSettings();
    }

    // 포톤 서버에 접속 후 호출되는 콜백 함수
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master!");
        Debug.Log($"PhotonNetwork.InLobby = { PhotonNetwork.InLobby}"); //로비에 입장 전이라 False;
        PhotonNetwork.JoinLobby(); //로비에 입장
        //base.OnConnectedToMaster();
    }

    // 로비에 접속 후 호출되는 콜백 함수
    public override void OnJoinedLobby()
    {
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}"); //로비에 입장 후라 True;
        PhotonNetwork.JoinRandomRoom(); // 램덤 매치메이킹 기능 제공
        //base.OnJoinedLobby();
    }

    // 램덤한 룸 입장이 실패 했을 경우 호출되는 콜백 함수
    public override void OnJoinRandomFailed(short returnCode, string message)
    //                                   어떤 에러 인지 확인 용도
    //                                                          메시지 출력
    {
        Debug.Log($"JoinRandom Filed {returnCode} : {message}");

        // 룸의 속성 정의
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20; //무료 접속은 20명 까지 가능이라 
        ro.IsOpen = true; //룸을 열기
        ro.IsVisible = true; //로비에서 공개 여부

        // 룸 생성
        PhotonNetwork.CreateRoom("My Room", ro);
        //base.OnJoinRandomFailed(returnCode, message);
    }

    // 룸 생성이 완료된 후 호출되는 콜백 함수
    public override void OnCreatedRoom()
    {
        Debug.Log("Create Room");
        // 방 이름
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
        //base.OnCreatedRoom();
    }

    // 룸에 입장한 후 호출되는 콜백 함수
    public override void OnJoinedRoom()
    {
        //들어온 방 이름
        Debug.Log($"PhotonNetwork.InRoom = {PhotonNetwork.InRoom}");
        
        // 현재 접속자 수
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");

        // 룸에 접속하 사용자 정보 확인
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            Debug.Log($"{player.Value.NickName}, {player.Value.ActorNumber}");
        }

        // 캐릭터 출현 정보를 배열에 저장
        Transform[] points = SpawnPointGroup.GetComponentsInChildren<Transform>();
        Debug.Log($"리스폰 추가 확인 : {points.Length}");
        int idx = Random.Range(1, points.Length);

        // 캐릭터 생성
        PhotonNetwork.Instantiate("Character", points[idx].position, points[idx].rotation, 0);
    }
}
