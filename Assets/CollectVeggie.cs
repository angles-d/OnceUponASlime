using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectVeggie : MonoBehaviour
{
    //public AudioSource collectSound;
    private GameObject player;

    private void Update()
    {
        //if you press V the character gets smaller
        if (Input.GetKeyDown(KeyCode.V)) {
            if (ScoreVeggie.getVeggieScoreNum() > 0)
            {
                gameObject.SetActive(false);
                float scale = 0.2f;

                player = GameObject.FindWithTag("Player");

                //she starts from scale 1 and lower by 0.2 each time
                if ((player.transform.localScale.x > 0.4) && (player.transform.localScale.y > 0.4) && (player.transform.localScale.z > 0.4))
                {
                    player.transform.localScale = new Vector3(player.transform.localScale.x - scale,
                    player.transform.localScale.y - scale, player.transform.localScale.z - scale);

                    ScoreVeggie.veggieScoreNum--;
                }


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //collectSound.Play();
        ScoreVeggie.veggieScoreNum++;
        gameObject.SetActive(false);

    }
}
