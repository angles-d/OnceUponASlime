using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    public DragonController dc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dc.anim.SetTrigger("Walk");
            dc.anim.ResetTrigger("Run");
            dc.speed -= 2;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dc.anim.SetTrigger("Run");
            dc.anim.ResetTrigger("Walk");
            dc.speed += 2;
        }
    }
}
