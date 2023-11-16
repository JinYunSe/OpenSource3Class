using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private string _gameVersion = "0.0.0";
    public string GameVersion
    {
        get
        {
            return _gameVersion;
        }
    }
    private string _nickName;
    public string NickName
    {
        set { _nickName = value; }
        get
        {
            return _nickName;
        }
    }
}
