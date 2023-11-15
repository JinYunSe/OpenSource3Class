using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    [SerializeField]
    float time = 0.2f;
    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Disappear", 0.2f);
        }
    }*/
    public void onUser()
    {
        Invoke("Disappear", time);
    }

    void Disappear()
    {
        gameObject.SetActive(false);
    }
}
