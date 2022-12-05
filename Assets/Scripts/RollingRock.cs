using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingRock : MonoBehaviour
{
    private const float ForcePower = 10f;
    public GameObject player;
    Rigidbody playerRb;
    Transform playerTransform;
    Rigidbody rb;
    public float speed = 2f;
    public float force = 2f;
    public bool isChasing = false;
    public Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerRb = player.GetComponent<Rigidbody>();
        playerTransform = player.GetComponent<Transform>();

    }

    private void FixedUpdate()
    {
        if (isChasing)
        {
            Chase();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isChasing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isChasing = false;
            Stop();
        }
    }

    private void Chase()
    {
        Vector3 directionTowardsTarget = (playerTransform.position - this.transform.position).normalized;
        //print(directionTowardsTarget);
        MoveTo(directionTowardsTarget);

        Vector3 deltaVelocity = direction * speed - rb.velocity;
        Vector3 moveForce = deltaVelocity * (force * ForcePower);
        print("Move:" + moveForce);
        rb.AddForce(moveForce);

    }

    public void MoveTo(Vector3 direction)
    {
        this.direction = direction;
    }

    public void Stop()
    {
        MoveTo(Vector3.zero);
    }



}


