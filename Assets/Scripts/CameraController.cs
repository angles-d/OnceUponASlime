using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    GameObject parent;
    public GameObject player;
    PlayerController pc;
    public float cameraDistance;
    public Movement move = Movement.Normal;
    float mY = 0.01f;
    float mZ = 0.2f;
    float dZ = 0;
    float dY = 1;

    public float slimeSize = 0;
    public enum Movement
    {
        Normal,
        ChangeSize
    }
   

    private void Start()
    {
        pc = player.GetComponent<PlayerController>();
        parent = player.transform.parent.gameObject;
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void LateUpdate()
    {
        if (!pc.playerIsDead)
        {
            if (move == Movement.Normal)
            {
                transform.position = player.transform.position - player.transform.forward * (cameraDistance + dZ);
                transform.LookAt(player.transform.position);
                transform.position = new Vector3(transform.position.x, transform.position.y + dY, transform.position.z);

            }
        }
        
    }

    public void ChangeSize()
    {
        //move = Movement.ChangeSize;
        dY += mY * slimeSize;
        dZ += mZ * slimeSize;
    }


}
