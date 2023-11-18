using UnityEngine;

public class ShootingGame : MonoBehaviour
{
    // TrueTarget �� FalseTarget�� �������� Unity Inspector���� �����ϱ� ���� ������
    public GameObject TrueTarget;
    public GameObject FalseTarget;

    // ������ ����Ǵ� �ð� �� Ÿ�̸�
    private float gameTime = 60f;
    private float timer = 0f;

    // ������ ���� ������ ���θ� ��Ÿ���� �÷���
    private bool gameIsRunning = true;

    // ������ ��Ÿ�� ���� ��ġ��
    private Vector3[] spawnPositions = {
        new Vector3(-9.72f, -0.56f, 19f),
        new Vector3(-11.02f, -0.56f, 19f),
        new Vector3(-8.42f, -0.56f, 19f)
    };

    void Start()
    {
        // ���� �������� SpawnTargets �Լ� ȣ�� ����
        InvokeRepeating("SpawnTargets", 2f, 3f);
    }

    void Update()
    {
        // ������ ���� ���� ��
        if (gameIsRunning)
        {
            // ��� �ð� ����
            timer += Time.deltaTime;

            // ������ ���� �ð��� ����ϸ� ���� ����
            if (timer >= gameTime)
            {
                EndGame();
            }
        }
    }

    void SpawnTargets()
    {
        // 1���� 3���� ������ ������ ���� ����
        int targetCount = Random.Range(1, 4);

        // ������ �� ���ῡ ���� �ݺ�
        for (int i = 0; i < targetCount; i++)
        {
            // 3���� �ڸ� �߿��� �����ϰ� ����
            int spawnPointIndex = Random.Range(0, spawnPositions.Length);
            Vector3 spawnPosition = spawnPositions[spawnPointIndex];

            // �����ϰ� TrueTarget �Ǵ� FalseTarget ����
            GameObject target = Instantiate(Random.Range(0, 2) == 0 ? TrueTarget : FalseTarget, spawnPosition, Quaternion.identity);

            // ������ ���ῡ ���� ���� (����, ��ũ��Ʈ ��)�� �߰��� �� ����

            // ���� �ð��� ���� �Ŀ� ������ ���� �ı�
            Destroy(target, 2f);
        }
    }

    void EndGame()
    {
        // ���� ���� �÷��� ���� �� �޽��� ���
        gameIsRunning = false;
        Debug.Log("Game Over!");
    }
}