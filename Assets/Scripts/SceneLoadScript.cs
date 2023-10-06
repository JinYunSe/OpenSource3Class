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
        string replaceNickName = nickName.text.Replace(" ", string.Empty);
        if (replaceNickName == string.Empty) return;
		PhotonHandler.Instance.nickName = replaceNickName;
        SceneManager.LoadScene(idx);
		Debug.Log("접속한 방 : "+idx);
	}
	
}
