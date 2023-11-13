using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GetPoint : MonoBehaviour
{
    Stopwatch watch = new Stopwatch();
    float time = 0;
    void OnEnable()
    {
        watch.Start();
    }

    void OnDisable()
    {
        watch.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        time = (float)watch.Elapsed.TotalSeconds;
        UnityEngine.Debug.Log(transform.root.gameObject.GetPhotonView().Controller.NickName+" , "+time);
    }
}
