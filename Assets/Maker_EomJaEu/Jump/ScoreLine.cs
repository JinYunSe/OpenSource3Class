using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreLine : MonoBehaviour
{
    public bool[] scoreline = new bool[] { false, false, false, false };
    private bool finish = false;
    private Collider Respawn;
    public GameObject character;

    public int CheckTrigger(Collider other)
    {
        if (other.gameObject.name == "Line0" && !scoreline[0])
        {
            scoreline[0] = true;
            Respawn = other;
            Debug.Log("저장");
        }
        else if (other.gameObject.name == "Line1" && !scoreline[1])
        {
            scoreline[1] = true;
            Respawn = other;
        }
        else if (other.gameObject.name == "Line2" && !scoreline[2])
        {
            scoreline[2] = true;
            Respawn = other;
        }
        else if (other.gameObject.name == "Line3" && !scoreline[3])
        {
            scoreline[3] = true;
            Respawn = other;
            gameObject.SetActive(false);
        }
        else if (other.gameObject.name == "UnderGround")
        {
            transform.position = other.transform.position;
                //new Vector3(Respawn.transform.position.x, Respawn.transform.position.y + 10, Respawn.transform.position.z); ;
            Debug.Log("텔포");
        }
            return 0;
    }

    public void Respawn_code()
    {
        Fixed_TPC fixed_TPC = new Fixed_TPC();

    }

    private void OnTriggerEnter(Collider other)
    {
        CheckTrigger(other);
        //Debug.Log("반응");
    }

    private void OnDisable()
    {
        if (!scoreline.Contains(false))
        {
            
        }
    }


}
