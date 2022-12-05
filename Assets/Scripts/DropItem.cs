using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject candy;
    public GameObject blob;

    public GameObject mesh;
    public AudioManager aud;

    void Drop()
    {
        if(Random.Range(-1, 1) >= 0)
        {
            Instantiate(candy, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z + 0.5f), Quaternion.identity);

        } else
        {
            Instantiate(blob, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z + 0.5f), Quaternion.identity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        aud.SpiderSquishSound();
        Destroy(mesh);
        Drop();
        Destroy(gameObject);
    }
}
