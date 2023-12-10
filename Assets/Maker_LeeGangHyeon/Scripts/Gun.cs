using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using StarterAssets;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Gun : MonoBehaviour {

    private AudioSource audioSource;
    private LeeGangHyeonThirdPersonController controller;
    public Transform RayPosition;
    private SphereCollider sphereCollider;

    private ShootingGame shootingGameScript;
    public Text ScoreText;
    public int score;
    private void Start()
    {
        controller = transform.root.GetComponent<LeeGangHyeonThirdPersonController>();
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.enabled = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();

        shootingGameScript = FindObjectOfType<ShootingGame>();
        if (controller.pv.IsMine)
        {
            string scoreTemp = ScoreText.text;
            score = int.Parse(Regex.Replace(scoreTemp, @"\D", string.Empty));
            Debug.Log("스코어 "+score);
        }
    }
    public void Shoot()
    {
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (controller.pv.IsMine)
        {
            Debug.Log("내 Tirger");
            if (other.CompareTag("TrueTarget"))
            {
                Destroy(other.gameObject);

                // TrueTarget 스폰 시간 목록을 가져와서 현재 시간과 비교
                List<float> trueTargetSpawnTimes = shootingGameScript.GetTrueTargetSpawnTimes();
                float timeSinceSpawn = Time.time - trueTargetSpawnTimes[trueTargetSpawnTimes.Count - 1];

                if (timeSinceSpawn <= 0.5f)
                {
                    score += 7;
                }
                else if (timeSinceSpawn <= 0.8f)
                {
                    score += 5;
                }
                else if (timeSinceSpawn <= 1.9f)
                {
                    score += 3;
                }
            }
            else if (other.CompareTag("FalseTarget"))
            {
                Destroy(other.gameObject);
                score -= 5;
            }
            ScoreText.text = "Score : " + score; 
        }
    }
}

