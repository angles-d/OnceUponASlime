using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDetectCollision : MonoBehaviour
{
    DragonHealth dh;

    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.CompareTag("Dragon Collider"))
        {

            dh = other.gameObject.GetComponent<DragonReference>().dragonHealth; 
            dh.Damage();
            Destroy(gameObject);
        }
    }
}
