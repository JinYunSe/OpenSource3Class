using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlat : MonoBehaviour
{
	public float fallTime = 1f;


	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			Debug.Log("유저 확인");
			//Debug.DrawRay(contact.point, contact.normal, Color.white);
			if (collision.gameObject.tag == "Player")
			{
				StartCoroutine(Fall(fallTime));
			}
		}
	}

	IEnumerator Fall(float time)
	{
		yield return new WaitForSecondsRealtime(time);
		gameObject.SetActive(false);
		Debug.Log("파괴 확인");
        yield return new WaitForSecondsRealtime(time);
        gameObject.SetActive(true);
        Debug.Log("생성 확인");
    }
}
