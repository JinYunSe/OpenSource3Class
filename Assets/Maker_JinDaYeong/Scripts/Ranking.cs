using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    private Dictionary<string, int> playerScores = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        // ���� ���� �� �÷��̾���� ���� �ʱ�ȭ
        InitializePlayerScores();
    }

    private void InitializePlayerScores()
    {
        // �÷��̾���� ������ �ʱ�ȭ�ϴ� �Լ�
        playerScores.Clear(); // ���� ���� �ʱ�ȭ

        // �÷��̾� ���� �ʱⰪ ����
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            string playerName = player.name;
            playerScores[playerName] = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string playerName = other.gameObject.name;

            UpdatePlayerScore(playerName);

            RankPlayers();

            // �÷��̾� ������Ʈ ����
            Destroy(other.gameObject); // Ʈ���ſ� ������ �÷��̾� ������Ʈ ����
        }
    }

    private void UpdatePlayerScore(string playerName)
    {
        // �÷��̾��� ���� ������Ʈ
        if (playerScores.ContainsKey(playerName))
        {
            // �÷��̾ Ʈ���ſ� ���� �� ���� �ο�
            if (playerScores[playerName] == 0)
            {
                playerScores[playerName] = 40;
            }
            else if (playerScores[playerName]==40)
            {
                playerScores[playerName] = 30;
            }
            else if (playerScores[playerName] == 30)
            {
                playerScores[playerName] = 20;
            }
            else if (playerScores[playerName]==20)
            {
                playerScores[playerName] = 10;
            }
        }
    }

    private void RankPlayers()
    {
        // �÷��̾���� ���� ������ �����ϰ� ������ �ű�� �Լ�
        List<KeyValuePair<string, int>> sortedPlayers = new List<KeyValuePair<string, int>>(playerScores);

        // ������ ���� �÷��̾� ����
        sortedPlayers.Sort((x, y) => y.Value.CompareTo(x.Value));

        // ���� �ο�
        int rank = 1;
        foreach (var player in sortedPlayers)
        {
            string playerName = player.Key;
            int playerScore = player.Value;
            Debug.Log($"Rank: {rank}, Player: {playerName}, Score: {playerScore}");

            // ���� ������Ʈ
            rank++;
        }
    }

}
