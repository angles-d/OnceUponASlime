using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCandy : MonoBehaviour
{

    //public AudioSource collectSound;

    private void OnTriggerEnter(Collider other)
    {
        //collectSound.Play();
        ScoreCandy.candyScoreNum++;
        Destroy(gameObject);

    }
}
