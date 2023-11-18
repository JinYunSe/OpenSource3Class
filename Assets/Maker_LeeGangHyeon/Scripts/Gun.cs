using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour {
	public Transform bulletImpact;
	public Transform explosion;
	ParticleSystem bulletps;
	ParticleSystem explosionPs;
    public GameObject TrueTarget;
    public GameObject FalseTarget;
    public Transform crossHair;

    Vector3 originSize;
	void Start()
	{
        originSize = crossHair.localScale * 3.2f;
        if (bulletImpact)
			bulletps = bulletImpact.GetComponent<ParticleSystem>();
		if(explosion)
			explosionPs = explosion.GetComponent<ParticleSystem>();
	}
    void Update()
    {
        // 마우스 좌클릭으로 총알 발사
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            
        }
    }

    void Shoot()
    {
        // crossHair를 기준으로 레이 생성
        Ray ray = new Ray(crossHair.position, crossHair.forward); //레이의 시작위치, 방향벡터
        RaycastHit hitInfo;

        // 레이캐스트를 통해 히트 스캔
        if (Physics.Raycast(ray, out hitInfo))
        {

            hitInfo.point= crossHair.position;
            crossHair.forward = -1 * ray.direction;
            crossHair.localScale = originSize * hitInfo.distance;
            // 총알 피격 효과 재생
            if (bulletImpact)
            {
                bulletImpact.up = hitInfo.normal;
                bulletImpact.position = hitInfo.point + hitInfo.normal * 0.2f;
                bulletps.Stop();
                bulletps.Play();
            }

            if (hitInfo.transform.name.Contains("True")) //수정해야함 파괴가 안됨
            {
                if (explosion)
                {
                    explosion.position = hitInfo.transform.position;
                    explosionPs.Stop();
                    explosionPs.Play();
                }
                Destroy(hitInfo.transform.gameObject);
            }
            else if (hitInfo.transform.name.Contains("False"))
            {
                if (explosion)
                {
                    explosion.position = hitInfo.transform.position;
                    explosionPs.Stop();
                    explosionPs.Play();
                }
                Destroy(hitInfo.transform.gameObject);
            }
           
            else
            {
                if (bulletImpact)
                {
                    bulletImpact.GetComponent<AudioSource>().Stop();
                    bulletImpact.GetComponent<AudioSource>().Play();
                }
            }
            Debug.Log(hitInfo.point);//디버그용 hitinfo 위치 
        }
    }
}

