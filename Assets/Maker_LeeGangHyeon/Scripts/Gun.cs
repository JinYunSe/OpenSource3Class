using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using StarterAssets;
using System.Collections.Generic;

public class Gun : MonoBehaviour {

	public ParticleSystem bulletPs;
    public ParticleSystem explosionPs;
    private AudioSource audioSource;
    private LeeGangHyeonThirdPersonController controller;
    public Transform RayPosition;
    public GameObject bullet;
    private SphereCollider sphereCollider;


    private bool isTrueTargetDestroyed = false;
    private float trueTargetDestroyTime;

    private ShootingGame shootingGameScript;

    private void Start()
    {
        controller = transform.root.GetComponent<LeeGangHyeonThirdPersonController>();
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.enabled = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();

        shootingGameScript = FindObjectOfType<ShootingGame>();
    }
    public void Shoot()
    {
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrueTarget"))
        {
            Destroy(other.gameObject);

            // TrueTarget 스폰 시간 목록을 가져와서 현재 시간과 비교
            List<float> trueTargetSpawnTimes = shootingGameScript.GetTrueTargetSpawnTimes();
            float timeSinceSpawn = Time.time - trueTargetSpawnTimes[trueTargetSpawnTimes.Count - 1];

            int scoreToAdd = CalculateScore(timeSinceSpawn);
            Score.score += scoreToAdd;
        }
        else if (other.CompareTag("FalseTarget"))
        {
            Destroy(other.gameObject);
            Score.score -= 5;
        }
    }
    private int CalculateScore(float timeSinceSpawn)
    {
        int score = 0;

        // 시간에 따라 점수 부여 로직 추가
        if (timeSinceSpawn <= 0.5f)
        {
            score = 7;
        }
        else if (timeSinceSpawn <= 0.8f)
        {
            score = 5;
        }
        else if (timeSinceSpawn <= 1.9f)
        {
            score = 3;
        }

        return score;
    }
}

