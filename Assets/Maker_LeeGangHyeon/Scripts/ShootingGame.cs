using UnityEngine;
using System.Collections.Generic;

public class ShootingGame : MonoBehaviour
{
    // Unity �����Ϳ��� �Ҵ��� Ÿ�� �����յ�
    public GameObject TrueTarget;
    public GameObject FalseTarget;

    // ���� ���� ����
    private float gameTime = 60f; // ���� �� ���� �ð� (��)
    private float timer = 0f; // ��� �ð��� �����ϴ� Ÿ�̸�
    private bool gameIsRunning = true; // ������ ���� ������ ���θ� ��Ÿ���� �÷���

    // �پ��� �׷쿡 ���� ���� ��ġ�� ������ �迭
    private List<Vector3>[] spawnPositionGroups;
    private List<Vector3> usedSpawnPositions = new List<Vector3>(); // ���� ���� ��ġ�� �����ϴ� ����Ʈ

    private List<float> trueTargetSpawnTimes = new List<float>();

    void Start()
    {

        // ���� ��ġ �׷� �ʱ�ȭ �� ������ �����̿� �ݺ� �������� Ÿ���� ���� ����
        InitializeSpawnPositionGroups();
        InvokeRepeating("SpawnTargets", 2f, 3f);
    }

    void Update()
    {
        // ������ ���� ���� �� Ÿ�̸� ������Ʈ �� ���� ���� �ð� Ȯ��
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
        // �� ���� �׷쿡 ���� ���� ��ġ �迭 �ʱ�ȭ
        spawnPositionGroups = new List<Vector3>[3];

        // �� �׷쿡 ���� ���� ��ġ ����
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
        foreach (var group in spawnPositionGroups)
        {
            // Ÿ���� TrueTarget���� FalseTarget���� �������� ����
            bool isTrueTarget = Random.Range(0, 2) == 0;

            // ���� �׷��� �� ���� ��ġ�� ���� �ݺ�
            foreach (var spawnPosition in group)
            {
                // ���� ��ġ���� Ÿ���� �����ϰ� ȸ�� ����
                GameObject target = Instantiate(isTrueTarget ? TrueTarget : FalseTarget, spawnPosition, Quaternion.identity);
                target.transform.rotation = Quaternion.Euler(90f, 0f, -180f);

                // Ÿ���� TrueTarget�̸� ���� �ð��� ����
                if (isTrueTarget)
                {
                    trueTargetSpawnTimes.Add(Time.time);
                }

                // 2�� �Ŀ� ������ Ÿ�� �ı�
                Destroy(target, 2f);
            }
        }
    }
    public List<float> GetTrueTargetSpawnTimes()
    {
        return trueTargetSpawnTimes;
    }

    void EndGame()
    {
        // ���� ���� �� �޽��� �α�
        gameIsRunning = false;
        Debug.Log("���� ����!");
        GameObject endGameCanvas = GameObject.Find("EndGameCanvas");
        if (endGameCanvas != null)
        {
            // EndGameUI�� �ڽ����� ���� ���
            Transform endGameUI = endGameCanvas.transform.Find("EndGameUI");
            if (endGameUI != null)
            {
                // ���ϴ� ���� ���� (��: Ȱ��ȭ)
                endGameUI.gameObject.SetActive(true);
            }
        }
    }
}
