using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    private Dictionary<string, int> playerScores = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        // 게임 시작 시 플레이어들의 점수 초기화
        InitializePlayerScores();
    }

    private void InitializePlayerScores()
    {
        // 플레이어들의 점수를 초기화하는 함수
        playerScores.Clear(); // 기존 점수 초기화

        // 플레이어 점수 초기값 설정
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

            // 플레이어 오브젝트 삭제
            Destroy(other.gameObject); // 트리거에 진입한 플레이어 오브젝트 삭제
        }
    }

    private void UpdatePlayerScore(string playerName)
    {
        // 플레이어의 점수 업데이트
        if (playerScores.ContainsKey(playerName))
        {
            // 플레이어가 트리거에 진입 시 점수 부여
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
        // 플레이어들을 점수 순으로 정렬하고 순위를 매기는 함수
        List<KeyValuePair<string, int>> sortedPlayers = new List<KeyValuePair<string, int>>(playerScores);

        // 점수에 따라 플레이어 정렬
        sortedPlayers.Sort((x, y) => y.Value.CompareTo(x.Value));

        // 순위 부여
        int rank = 1;
        foreach (var player in sortedPlayers)
        {
            string playerName = player.Key;
            int playerScore = player.Value;
            Debug.Log($"Rank: {rank}, Player: {playerName}, Score: {playerScore}");

            // 순위 업데이트
            rank++;
        }
    }

}
