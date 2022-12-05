using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCandy : MonoBehaviour
{

    public Text candyScoreText;
    public static int candyScoreNum;

    private void Start()
    {
        candyScoreNum = 0;
    }
    void Update()
    {
        candyScoreText.text = candyScoreNum.ToString();
    }
}
