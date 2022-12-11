using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class disable_airabbit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject tree;
    public GameObject bunny;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //         player = GameObject.Find("Player");
        // tree = GameObject.Find("Oak_Tree");
        // bunny = GameObject.Find("rabbitai");
        // Debug.Log((player.transform.position-tree.transform.position).magnitude);
      if((player.transform.position-tree.transform.position).magnitude<280)
          bunny.SetActive(true);
      else
          bunny.SetActive(false);
        
    }
}
