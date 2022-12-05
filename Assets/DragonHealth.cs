using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHealth : MonoBehaviour
{

    public float maxHealth;
    public float currHealth;
    public float damage;
    DragonController dc;
    EnemyHeartController ec;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        dc = GetComponent<DragonController>();
        ec = GetComponent<EnemyHeartController>();
        maxHealth = ec.numHearts;
        currHealth = maxHealth;
    }


    public void Damage()
    {     
        print("dragon hit");
        AdjustDragonHealth(1);
        ec.HeartLost();
    }


    public void AdjustDragonHealth(float factor)
    {
        currHealth -= factor;

        if (currHealth <= 0)
        {
            dc.Die();
        }

        if (currHealth > maxHealth)
        {
            currHealth = maxHealth;
        }

    }

    
}
