using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    [SerializeField]
    float time = 0.2f;
    
    public void OnTheFloor()
    {
        Invoke("Disappear", time);
    }

    void Disappear()
    {
        gameObject.SetActive(false);
    }
}
