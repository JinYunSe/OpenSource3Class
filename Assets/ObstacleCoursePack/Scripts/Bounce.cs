using Photon.Pun;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson.PunDemos;

public class Bounce : MonoBehaviour
{
	public float force = 10f; //Force 10000f
	public float stunTime = 0.5f;
	private Vector3 hitDir;

	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			if (collision.gameObject.tag == "Player")
			{
				hitDir = contact.normal;
                Debug.Log(PhotonNetwork.LocalPlayer.NickName + " : " + hitDir);
                collision.gameObject.GetComponent<ThirdPersonController>().HitPlayer(-hitDir * force);
                return;
			}
		}
	}
}
