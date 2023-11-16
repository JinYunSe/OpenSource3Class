using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootTile : MonoBehaviour
{
    // Start is called before the first frame update
    private SphereCollider foot;
    void Start()
    {
        foot = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) return;
        if (other.CompareTag("Floor"))
        {
            other.GetComponent<TileController>().onUser();
        }
    }
}
