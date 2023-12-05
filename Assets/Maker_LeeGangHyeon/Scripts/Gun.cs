using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using StarterAssets;

public class Gun : MonoBehaviour {

	public ParticleSystem bulletPs;
    public ParticleSystem explosionPs;
    private AudioSource audioSource;
    private LeeGangHyeonThirdPersonController controller;
    public Transform RayPosition;
    public GameObject bullet;
    private SphereCollider sphereCollider;
    private void Start()
    {
        controller = transform.root.GetComponent<LeeGangHyeonThirdPersonController>();
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.enabled = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawRay(RayPosition.position, RayPosition.transform.right * -7);
    }
    public void Shoot()
    {
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrueTarget"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("FalseTarget"))
        {
            Destroy(other.gameObject);
        }
    }
}

