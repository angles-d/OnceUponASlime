using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RabbitHelp : RabbitState
{
    public GameObject playerobject;
    public GameObject castleobject;
    public bool changetoidle;
    public RabbitIdle idlestate;
    public bool changetoalert;
    public RabbitAlert alertstate;

    Camera cam;

    Vector3 player_pos;
    Vector3 castle_pos;
    public int min = -5;
    public int max = 5;

    public override RabbitState RunCurrentState(NavMeshAgent agent)
    {

        changetoidle=playerobject.GetComponent<Rigidbody>().velocity.y==0.0;
        changetoalert=playerobject.GetComponent<Rigidbody>().velocity.y<-0.2;
        cam = GetComponent<Camera>();
        if (changetoidle)
        {
            return idlestate;
        }
        else if(changetoalert)
        {
            return alertstate;
        }
        else
        {
            //Debug.Log(playerobject.GetComponent<Rigidbody>().velocity);
            player_pos=new Vector3(playerobject.transform.position.x, 0, playerobject.transform.position.z);
            castle_pos=new Vector3(castleobject.transform.position.x, 0, castleobject.transform.position.z);
            agent.destination=castle_pos-player_pos+randomTarget(min, max);
            return this;
        }
        
    }
        Vector3 randomTarget(float minVal, float maxVal)
    {
        return new Vector3(Random.Range(minVal, maxVal), 0,  Random.Range(minVal, maxVal));
    }
}
