using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterTerritory : MonoBehaviour
{
    public GameObject dragon;
    DragonController dc;

    private void Start()
    {
        dc = dragon.GetComponent<DragonController>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dc.isChasing = true;
            dc.Roar();
            dc.anim.SetTrigger("Run");
            dc.speed += 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dc.isChasing = false;
            dc.breatheFire = false;
            dc.timer = dc.fireTime;
            dc.speed -= 2;

            dc.turnAround = true;
            StartCoroutine(dc.SlowTurn());
                

        }
    }
    
}

