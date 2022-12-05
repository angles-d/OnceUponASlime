using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RabbitStateManager : MonoBehaviour
{
    public RabbitState currentState;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }
    void Update()
    {

        RunStateMachine();
    }
    private void RunStateMachine()
    {
        
        RabbitState nextState=currentState?.RunCurrentState(agent);
        if(nextState!=null)
        {
            //Switch to the next state
            SwitchToTheNextState(nextState);
        }
    }
    private void SwitchToTheNextState(RabbitState nextState)
    {
        currentState=nextState;
    }
}
