using UnityEngine;
using System.Collections.Generic;

public class ShootingGame : MonoBehaviour
{
    // Unity 에디터에서 할당할 타겟 프리팹들
    public GameObject TrueTarget;
    public GameObject FalseTarget;

    // 게임 관련 변수
    private float gameTime = 60f; // 게임 총 지속 시간 (초)
    private float timer = 0f; // 경과 시간을 추적하는 타이머
    private bool gameIsRunning = true; // 게임이 진행 중인지 여부를 나타내는 플래그

    // 다양한 그룹에 대한 스폰 위치를 저장할 배열
    private List<Vector3>[] spawnPositionGroups;
    private List<Vector3> usedSpawnPositions = new List<Vector3>(); // 사용된 스폰 위치를 추적하는 리스트

    void Start()
    {
        // 스폰 위치 그룹 초기화 및 일정한 딜레이와 반복 간격으로 타겟을 스폰 시작
        InitializeSpawnPositionGroups();
        InvokeRepeating("SpawnTargets", 2f, 3f);
    }

    void Update()
    {
        // 게임이 진행 중일 때 타이머 업데이트 및 게임 지속 시간 확인
        if (gameIsRunning)
        {
            timer += Time.deltaTime;
            if (timer >= gameTime)
            {
                EndGame();
            }
        }
    }

    void InitializeSpawnPositionGroups()
    {
        // 세 가지 그룹에 대한 스폰 위치 배열 초기화
        spawnPositionGroups = new List<Vector3>[3];

        // 각 그룹에 대한 스폰 위치 정의
        spawnPositionGroups[0] = new List<Vector3>
        {
            new Vector3(-10.43f, -1f, 19f),
            new Vector3(-4.37f, -1f, 19f),
            new Vector3(2.33f, -1f, 19f),
            new Vector3(9.15f, -1f, 19f),
        };

        spawnPositionGroups[1] = new List<Vector3>
        {
            new Vector3(-8.7f, -1f, 19f),
            new Vector3(-2.65f, -1f, 19f),
            new Vector3(3.94f, -1f, 19f),
            new Vector3(10.72f, -1f, 19f),
        };

        spawnPositionGroups[2] = new List<Vector3>
        {
            new Vector3(-7.12f, -1f, 19f),
            new Vector3(-1.14f, -1f, 19f),
            new Vector3(5.45f, -1f, 19f),
            new Vector3(12.29f, -1f, 19f),
        };
    }

    void SpawnTargets()
    {
        // 각 스폰 위치 그룹에 대해 반복
        foreach (var group in spawnPositionGroups)
        {
                // 타겟이 TrueTarget인지 FalseTarget인지 랜덤으로 결정
                bool isTrueTarget = Random.Range(0, 2) == 0;

                // 현재 그룹의 각 스폰 위치에 대해 반복
                foreach (var spawnPosition in group)
                {
                    // 스폰 위치에서 타겟을 생성하고 회전 설정
                    GameObject target = Instantiate(isTrueTarget ? TrueTarget : FalseTarget, spawnPosition, Quaternion.identity);
                    target.transform.rotation = Quaternion.Euler(90f, 0f, -180f);

                // 2초 후에 생성된 타겟 파괴
                Destroy(target, 2f);
            }
        }
    }

    void EndGame()
    {
        // 게임 종료 및 메시지 로그
        gameIsRunning = false;
        Debug.Log("게임 종료!");
    }
}
