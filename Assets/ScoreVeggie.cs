using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreVeggie : MonoBehaviour
{
    public Text veggieScoreText;
    public static int veggieScoreNum = 0;

    void Update()
    {
        veggieScoreText.text = veggieScoreNum.ToString();
    }

    public static int getVeggieScoreNum()
    {
        return veggieScoreNum;
    }
}
