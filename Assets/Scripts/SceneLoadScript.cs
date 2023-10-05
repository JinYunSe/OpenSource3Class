using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadScript : MonoBehaviour
{
	public void LoadScene(int idx)
	{
		SceneManager.LoadScene(idx);
		Debug.Log("접속한 방 : "+idx);
	}
	
}
