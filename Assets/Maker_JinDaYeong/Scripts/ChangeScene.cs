using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Scene currScene = SceneManager.GetActiveScene();
        switch (currScene.name)
        {
            case "MainGame":
                SceneManager.LoadScene("GameOver"); break;
        }
    }
}
