using UnityEngine;

public class ShootingGame : MonoBehaviour
{
    // TrueTarget 및 FalseTarget의 프리팹을 Unity Inspector에서 설정하기 위한 변수들
    public GameObject TrueTarget;
    public GameObject FalseTarget;

    // 게임이 진행되는 시간 및 타이머
    private float gameTime = 60f;
    private float timer = 0f;

    // 게임이 진행 중인지 여부를 나타내는 플래그
    private bool gameIsRunning = true;

    // 과녁이 나타날 고정 위치들
    private Vector3[] spawnPositions = {
        new Vector3(-9.72f, -0.56f, 19f),
        new Vector3(-11.02f, -0.56f, 19f),
        new Vector3(-8.42f, -0.56f, 19f)
    };

    void Start()
    {
        // 일정 간격으로 SpawnTargets 함수 호출 시작
        InvokeRepeating("SpawnTargets", 2f, 3f);
    }

    void Update()
    {
        // 게임이 진행 중일 때
        if (gameIsRunning)
        {
            // 경과 시간 측정
            timer += Time.deltaTime;

            // 지정된 게임 시간이 경과하면 게임 종료
            if (timer >= gameTime)
            {
                EndGame();
            }
        }
    }

    void SpawnTargets()
    {
        // 1부터 3까지 랜덤한 개수의 과녁 생성
        int targetCount = Random.Range(1, 4);

        // 생성된 각 과녁에 대해 반복
        for (int i = 0; i < targetCount; i++)
        {
            // 3개의 자리 중에서 랜덤하게 선택
            int spawnPointIndex = Random.Range(0, spawnPositions.Length);
            Vector3 spawnPosition = spawnPositions[spawnPointIndex];

            // 랜덤하게 TrueTarget 또는 FalseTarget 생성
            GameObject target = Instantiate(Random.Range(0, 2) == 0 ? TrueTarget : FalseTarget, spawnPosition, Quaternion.identity);

            // 생성된 과녁에 대한 설정 (색상, 스크립트 등)을 추가할 수 있음

            // 일정 시간이 지난 후에 생성된 과녁 파괴
            Destroy(target, 2f);
        }
    }

    void EndGame()
    {
        // 게임 종료 플래그 설정 및 메시지 출력
        gameIsRunning = false;
        Debug.Log("Game Over!");
    }
}