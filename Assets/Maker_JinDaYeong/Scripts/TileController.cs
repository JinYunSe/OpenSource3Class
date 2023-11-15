using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Disappear", 0.2f);
        }
    }

    void Disappear()
    {
        gameObject.SetActive(false);
    }
}
