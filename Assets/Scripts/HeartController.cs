using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    public int numHearts;
    public int maxHearts;
    public GameObject[] hearts;
    public bool isDead = false;


    public GameObject panel;
    // Start is called before the first frame update

    private void Start()
    {
        maxHearts = hearts.Length;
        for (int i  = numHearts; i <maxHearts; i++)
        {
            hearts[i].SetActive(false);
        }
    }


    public void AddHeart()
    {
        if (numHearts < maxHearts)
        {
            hearts[numHearts].SetActive(true);
            numHearts++;

        }
    }

    public void LoseHeart()
    {
        if (numHearts > 1)
        {
            numHearts--;
            hearts[numHearts].SetActive(false);

        } else
        {
            //player out of hearts
            hearts[0].SetActive(false);
            isDead = true;
            print("die");
        }
    }
}
