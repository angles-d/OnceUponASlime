using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeartController : MonoBehaviour
{
    public int numHearts;
    int curHeart;
    public GameObject[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        numHearts = hearts.Length;
        curHeart = numHearts - 1;
    }

    public void HeartLost()
    {
        if (curHeart >= 0)
        {
            hearts[curHeart].SetActive(false);
            curHeart--;
        }
    }

    public void FacePlayer()
    {

    }
}
