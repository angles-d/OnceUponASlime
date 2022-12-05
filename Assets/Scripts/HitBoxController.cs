using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitBoxController : MonoBehaviour
{
    public GameObject parent;
    Controller parentController;
    string parentTag;

    private void Awake()
    {
        parentController = parent.GetComponent<Controller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (parentController is SpiderController)
            {
                print("Spider Controller");
                if (other.transform.position.y >= 0.3)
                {
                    Debug.Log("sent hit");
                    parentController.Hit();
                }
            }
        }
    }
}
