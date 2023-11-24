using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject gameOverScreen; // ���� ���� ȭ��
    public GameObject winScreen; // �¸� ȭ��
    public Text playerRankText; // �÷��̾� ������ ǥ���� �ؽ�Ʈ

    private List<GameObject> players; // ���ӿ� �����ϴ� �÷��̾���� ����Ʈ
    private bool gameOver = false; // ���� ���� ���θ� Ȯ���ϴ� ����

    private void Start()
    {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player")); // ���� ���� �� �÷��̾���� ã�� ����Ʈ�� �߰�
    }

    private void Update()
    {
        if (gameOver)
        {
            return;
        }

        // �÷��̾���� y�� ��ġ�� Ȯ���Ͽ� ���� ���� ���� �Ǻ�
        foreach (GameObject player in players)
        {
            if (player.transform.position.y <= -5)
            {
                ShowGameOverScreen(player); // ���� ���� ȭ�� ǥ��
                return;
            }
        }

        // 1�� �÷��̾ ã�Ƽ� �¸� ȭ�� ǥ��
        GameObject firstPlacePlayer = FindFirstPlacePlayer();
        if (firstPlacePlayer != null)
        {
            ShowWinScreen(firstPlacePlayer);
            return;
        }
    }

    // 1�� �÷��̾ ã�� �Լ�
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

    // ���� ���� ȭ���� ǥ���ϴ� �Լ�
    private void ShowGameOverScreen(GameObject losingPlayer)
    {
        gameOver = true;
        gameOverScreen.SetActive(true); // ���� ���� ȭ�� Ȱ��ȭ

        players.Remove(losingPlayer); // �÷��̾� ����Ʈ���� Ż���� �÷��̾� ����
        int rank = players.Count + 1; // Ż���� �÷��̾��� ���� ���
        playerRankText.text = $"You finished in {rank} place"; // ������ ȭ�鿡 ǥ��

        // �� ������ ���� �� �ε�
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

    // �¸� ȭ���� ǥ���ϴ� �Լ�
    private void ShowWinScreen(GameObject winningPlayer)
    {
        gameOver = true;
        winScreen.SetActive(true); // �¸� ȭ�� Ȱ��ȭ

        int score = CalculateScore(players.IndexOf(winningPlayer) + 1); // �÷��̾��� ���� ���
        Debug.Log($"Player scored: {score}"); // ������ ����� �α׷� ���
    }

    // ������ ���� ���� ����ϴ� �Լ�
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
