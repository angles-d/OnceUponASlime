using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlimeTreeCollision : MonoBehaviour
{
    [Header ("Custom Event")]
    //private Animator anim;
    //public GameObject trees;
    //public GameObject slime;
    // Start is called before the first frame update

    public UnityEvent myEvents;
    //void Start()
    //{
    //    anim = GetComponent<Animator>();
    //    //trees = GetComponent<GameObject>();
    //    //slime = GetComponent<GameObject>();
    //}


    public void OnTriggerEnter(Collider other)

    {
        //anim.Play("Slime Bounce");
        if (myEvents == null)
        {
            print("trigger no event");
        }
        else
        {
            print("event triggered and activating");
            myEvents.Invoke();
        }

    }
}