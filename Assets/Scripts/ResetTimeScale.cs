using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTimeScale: MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1f;
        print("Time:"+Time.timeScale);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
