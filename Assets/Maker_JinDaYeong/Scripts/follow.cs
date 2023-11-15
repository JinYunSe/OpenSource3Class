using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class follow : MonoBehaviour
{
    public class Define
    {
        public enum CameraMode
        {
            QuaterView,
        }
    }
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuaterView;

    [SerializeField]
    Vector3 _delta;

    GameObject _player;

    private PhotonView pv;
    private void Start()
    {
        if (!pv.IsMine) return;
        transform.parent = _player.transform;
    }

    void LateUpdate()
    {
        if (!pv.IsMine) return;
        if (_mode == Define.CameraMode.QuaterView)
        {
            transform.position = _player.transform.position + _delta;
            transform.LookAt(_player.transform);
        }
    }
}
