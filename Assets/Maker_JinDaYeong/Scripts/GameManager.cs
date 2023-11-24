using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject gameOverScreen; // 게임 오버 화면
    public GameObject winScreen; // 승리 화면
    public Text playerRankText; // 플레이어 순위를 표시할 텍스트

    private List<GameObject> players; // 게임에 참여하는 플레이어들의 리스트
    private bool gameOver = false; // 게임 오버 여부를 확인하는 변수

    private void Start()
    {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player")); // 게임 시작 시 플레이어들을 찾아 리스트에 추가
    }

    private void Update()
    {
        if (gameOver)
        {
            return;
        }

        // 플레이어들의 y축 위치를 확인하여 게임 오버 여부 판별
        foreach (GameObject player in players)
        {
            if (player.transform.position.y <= -5)
            {
                ShowGameOverScreen(player); // 게임 오버 화면 표시
                return;
            }
        }

        // 1위 플레이어를 찾아서 승리 화면 표시
        GameObject firstPlacePlayer = FindFirstPlacePlayer();
        if (firstPlacePlayer != null)
        {
            ShowWinScreen(firstPlacePlayer);
            return;
        }
    }

    // 1위 플레이어를 찾는 함수
    private GameObject FindFirstPlacePlayer()
    {
        GameObject firstPlacePlayer = null;
        float maxYPosition = float.MinValue;

        foreach (GameObject player in players)
        {
            float yPos = player.transform.position.y;
            if (yPos > maxYPosition)
            {
                maxYPosition = yPos;
                firstPlacePlayer = player;
            }
        }

        return firstPlacePlayer;
    }

    // 게임 오버 화면을 표시하는 함수
    private void ShowGameOverScreen(GameObject losingPlayer)
    {
        gameOver = true;
        gameOverScreen.SetActive(true); // 게임 오버 화면 활성화

        players.Remove(losingPlayer); // 플레이어 리스트에서 탈락한 플레이어 제거
        int rank = players.Count + 1; // 탈락한 플레이어의 순위 계산
        playerRankText.text = $"You finished in {rank} place"; // 순위를 화면에 표시

        // 각 순위에 따른 씬 로드
        switch (rank)
        {
            case 4:
                SceneManager.LoadScene("4thScene");
                break;
            case 3:
                SceneManager.LoadScene("3rdScene");
                break;
            case 2:
                SceneManager.LoadScene("2ndScene");
                break;
            case 1:
                SceneManager.LoadScene("WinScene");
                break;
        }
    }

    // 승리 화면을 표시하는 함수
    private void ShowWinScreen(GameObject winningPlayer)
    {
        gameOver = true;
        winScreen.SetActive(true); // 승리 화면 활성화

        int score = CalculateScore(players.IndexOf(winningPlayer) + 1); // 플레이어의 점수 계산
        Debug.Log($"Player scored: {score}"); // 점수를 디버그 로그로 출력
    }

    // 순위에 따른 점수 계산하는 함수
    private int CalculateScore(int rank)
    {
        switch (rank)
        {
            case 1:
                return 40;
            case 2:
                return 30;
            case 3:
                return 20;
            case 4:
                return 10;
            default:
                return 0;
        }
    }
}
