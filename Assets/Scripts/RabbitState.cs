using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public abstract class RabbitState : MonoBehaviour
{

   public abstract RabbitState RunCurrentState(NavMeshAgent agent);

}
