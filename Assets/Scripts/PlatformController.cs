using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    public GameObject platformPathStart;
    public GameObject platformPathEnd;
    public int speed;
    private Vector3 startPosition;
    private Vector3 endPosition;

    IEnumerator Vector3LerpCoroutine(GameObject obj, Vector3 target, float speed)
    {
        Vector3 startPosition = obj.transform.position;
        float time = 0f;

        while (obj.transform.position != target)
        {
            obj.transform.position = Vector3.Lerp(startPosition, target, (time / Vector3.Distance(startPosition, target)) * speed);
            time += Time.deltaTime;
            yield return null;
        }
    }

    private void Start()
    {
        startPosition = platformPathStart.transform.position;
        endPosition = platformPathEnd.transform.position;
        StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
    }

    private void Update()
    {
        if (transform.position == endPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
        }

        if (transform.position == startPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
        }
        
    }

    //public bool xMove = true;
    //public bool yMove = true;
    //public float xMin = 0;
    //public float xMax = 0;
    //public float yMin = 0;
    //public float yMax = 0;
    //public float speed = 3f;
    //public Vector3 xDirection;
    //public Vector3 yDirection;

    //Vector3 move;
    //Rigidbody rb;

    //private void Start()
    //{
    //    float xPos = transform.position.x;
    //    float yPos = transform.position.y;

    //    rb = GetComponent<Rigidbody>();

    //    xDirection = xMove ? new Vector3(1, 0, 0) : new Vector3(0, 0, 0);
    //    yDirection = yMove ? new Vector3(0, 1, 0) : new Vector3(0, 0, 0);

    //    xMin = xMin + xPos;
    //    xMax = xMax + xPos;

    //    yMin = yMin + yPos;
    //    yMax = yMax + yPos;

    //    float startX = xMove ? Random.Range(xMin, xMax) : xPos;
    //    float startY = yMove ? Random.Range(yMin, yMax) : yPos;

    //    transform.position = new Vector3(startX, startY, transform.position.z);

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (xMove)
    //    {
    //        float x = transform.position.x;

    //        if (x <= xMin || x >= xMax)
    //        {
    //            xDirection *= -1;
    //        }
    //    }

    //    if (yMove)
    //    {
    //        float y = transform.position.y;
    //        if (y <= yMin || y >= yMax)
    //        {
    //            yDirection *= -1;
    //        }
    //    }

    //    move = xDirection + yDirection;

    //    transform.position += move * speed * Time.deltaTime;

    //}

}
