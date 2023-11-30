using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class GetPoint : MonoBehaviour
{
    Stopwatch watch = new Stopwatch();
    public Text TimerText;
    private float time = 0;
    private PhotonView PV;
    private void Start()
    {
        PV = transform.root.GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            TimerText.gameObject.SetActive(true);
        }
    }

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
        if (PV.IsMine)
        {
            TimerText.gameObject.transform.parent.gameObject.SetActive(true);
            time = (float)watch.Elapsed.TotalSeconds;
            TimerText.text = "GetTime : " + Mathf.Floor(time).ToString();
            //UnityEngine.Debug.Log(transform.root.gameObject.GetPhotonView().Controller.NickName + " , " + time);
        }
        else
        {
            TimerText.gameObject.transform.parent.gameObject.SetActive(false);
            time = (float)watch.Elapsed.TotalSeconds;
            TimerText.text = "GetTime : " + Mathf.Floor(time).ToString();
            //UnityEngine.Debug.Log(transform.root.gameObject.GetPhotonView().Controller.NickName + " , " + time);
        }
    }
}
