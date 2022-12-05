using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VeggieInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private Text count;
    // Start is called before the first frame update
    void Start()
    {
        count = GetComponent<Text>();
    }

    // Update is called once per frame
    public void UpdateVeggieCount(float num)
    {
        count.text = num.ToString();
    }
}
