using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeTrigger : MonoBehaviour
{
    public float scale = 0.15f;
    Vector3 scaleVec;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        scaleVec = new Vector3(scale, scale, scale);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //    private void OnTriggerEnter(Collider other)
    //    {
    //        if (other.gameObject.tag == "Player")
    //        {
    //            gameObject.SetActive(false);
    //            Debug.Log("SLIME MAKES YOU BIGGER");
    //            player.Grow();

    //        }
    //    }
}
