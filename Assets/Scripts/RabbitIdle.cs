using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RabbitIdle : RabbitState
{
    public GameObject playerobject;
    public GameObject castleobject;
    public GameObject followme;
    public bool changetohelp;
    public bool changetoalert;
    public RabbitHelp helpstate;
    public RabbitAlert alertstate;

    public Camera cam;
    public GameObject followmeui;

    
    public int min = 2;
    public int max = 5;
    Vector3 player_pos;
    Vector3 rand_target;

    public override RabbitState RunCurrentState(NavMeshAgent agent)
    {
        // cam = GetComponent<Camera>();
        Vector3 screenPoint = cam.WorldToViewportPoint(castleobject.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        
        // changetohelp=playerobject.GetComponent<Rigidbody>().velocity.y>0.2;
        changetoalert=!onScreen;


        // agent = GetComponent<NavMeshAgent>();
        // if (changetohelp)
        // {
        //     return helpstate;
        // }
        if(changetoalert)
        {
            return alertstate;
        }
        else
        {
            //Debug.Log("in idle");
            followme.SetActive(false);
            followmeui.SetActive(false);
            player_pos=new Vector3(playerobject.transform.position.x, 0, playerobject.transform.position.z);
            rand_target=randomTarget(min, max);
            
            
            agent.destination=player_pos+rand_target;
            return this;
        }

        
    }
        Vector3 randomTarget(float minVal, float maxVal)
    {
        return new Vector3(Random.Range(minVal, maxVal), 0,  Random.Range(minVal, maxVal));
    }
}
