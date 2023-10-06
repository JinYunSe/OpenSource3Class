using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadScript : MonoBehaviour
{
	[SerializeField]
	private Text nickName;
	public void LoadScene(int idx)
	{ 
		PhotonHandler.Instance.nickName = nickName.text;
        SceneManager.LoadScene(idx);
		Debug.Log("접속한 방 : "+idx);
	}
	
}
