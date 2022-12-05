using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RabbitAlert : RabbitState
{
    public GameObject playerobject;
    public GameObject castleobject;
    public GameObject followme;
    public bool changetoidle;
    public RabbitIdle idlestate;
    public bool changetohelp;
    public RabbitHelp helpstate;
    // public Animator anim;

    public Camera cam;
    public GameObject followmeui;
    Vector3 player_pos;
    Vector3 castle_pos;
    public int min = 0;
    public int max = 2;


    public override RabbitState RunCurrentState(NavMeshAgent agent)
    {
        // changetoidle=playerobject.GetComponent<Rigidbody>().velocity.y==0.0;
        // changetohelp=playerobject.GetComponent<Rigidbody>().velocity.y>0.2;
        // cam = GetComponent<Camera>();
        Vector3 screenPoint = cam.WorldToViewportPoint(castleobject.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        changetoidle=onScreen;
        // renderer=GetComponent<Renderer>();
        if (changetoidle)
        {
            return idlestate;
        }
        // else if(changetohelp)
        // {
        //     return helpstate;
        // }
        else 
        {
            //Debug.Log("alert-not in castle view");
            followme.SetActive(true);
            followmeui.SetActive(true);
            
            player_pos=new Vector3(playerobject.transform.position.x, 0, playerobject.transform.position.z);
            castle_pos=new Vector3(castleobject.transform.position.x, 0, castleobject.transform.position.z);
            Vector3 dir = (castle_pos-player_pos ).normalized;
            agent.destination=player_pos+dir*8;
            return this;
        }
    }
        Vector3 randomTarget(float minVal, float maxVal)
    {
        return new Vector3(Random.Range(minVal, maxVal), 0,  Random.Range(minVal, maxVal));
    }
}
