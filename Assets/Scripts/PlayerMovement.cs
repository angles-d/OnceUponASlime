using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float rotateSpeed = 5;
    public float jumpHeight = 3;

    public bool onGround = true;

    private Rigidbody rb;
    public Animator anim;
    PlayerController pc;
    GameObject parent;

    public CandyInventory candyItem;
    public VeggieInventory veggieItem;
    public float candyCount = 0;
    public float veggieCount = 0;


    public GameObject proj;
    public float proj_speed = 700f;


    public float speedBoostTime = 3f;
    public float boost = 3f;
    float rotBoost;
    bool speedBoost = false;
    float runningSBTime = 0;

    public float shootCDTime = 1f;
    float runningCDTime = 0;
    bool shootCoolDown = false;

    public AudioManager aud;

    public bool isOnPlatform;
   
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        candyItem = GameObject.Find("candyCount").GetComponent<CandyInventory>();
        veggieItem = GameObject.Find("veggieCount").GetComponent<VeggieInventory>();

        rotBoost = boost * 20;

        parent = transform.parent.gameObject;

    }


    void OnJump()
    {
        CheckGround();
        if (onGround)
        {
            rb.AddForce(jumpHeight * Vector3.up, ForceMode.Impulse);
            onGround = false;
            anim.SetTrigger("Jump");
            if (aud != null)
            {
                aud.SlimeJumpSound();
            }   
        }
    }


    private void Update()
    {
        if (!pc.playerIsDead)
        {
            //start of player movement
            Vector3 movement = new Vector3(0f, 0.0f, 0f);

            if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    if (Input.GetKey(KeyCode.A))
                    {
                        transform.Rotate(-rotateSpeed * Time.deltaTime * Vector3.up);
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                       transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.up);
                    }
                    else
                    {
                        movement += transform.forward;
                    }
                } else {
                    if (Input.GetKey(KeyCode.S))
                    {
                        movement += -transform.forward;
                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        movement += -transform.right;
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                        movement += transform.right;
                    }
                }
            } else {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (Input.GetKey(KeyCode.LeftArrow)) {
                        transform.Rotate(-rotateSpeed * Time.deltaTime * Vector3.up);

                    } else if (Input.GetKey(KeyCode.RightArrow)) {
                        transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.up);
                    } else {
                        movement += transform.forward;
                    }
                } else {
                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        movement += -transform.forward;

                    } else if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        movement += -transform.right;

                    } else if (Input.GetKey(KeyCode.RightArrow))
                    {
                        movement += transform.right;
                    }
                }
            }

            parent.transform.position += movement * Time.deltaTime * speed;

            //transform.localPosition = movement * Time.deltaTime * speed;
            //parent.transform.position += transform.localPosition;
            //transform.localPosition = Vector3.zero;
            //end of player movement


            //check cooldowns

            if (shootCoolDown)
            {
                if (runningCDTime > 0)
                {
                    runningCDTime -= Time.deltaTime;
                }
                else
                {
                    shootCoolDown = false;
                }
                
            }
            

            if (speedBoost)
            {
                if (runningSBTime > 0)
                {
                    runningSBTime -= Time.deltaTime;
                }
                else
                {
                    speed -= boost;
                    rotateSpeed -= rotBoost;
                    speedBoost = false;
                }
             }

            if (!speedBoost && veggieCount > 0 && Input.GetKeyDown(KeyCode.V))
            {
                speed += boost;
                rotateSpeed += rotBoost;
                veggieCount--;
                veggieItem.UpdateVeggieCount(veggieCount);
                speedBoost = true;
                runningSBTime = speedBoostTime;
            }

            if (!shootCoolDown && candyCount > 0 && Input.GetKeyDown(KeyCode.C))
            {
                ShootProjectile();
                aud.CandyShootSound();
                candyCount--;
                candyItem.UpdateCandyCount(candyCount);
                shootCoolDown = true;
                runningCDTime = shootCDTime;
            }


            
        }

    }

    void CheckGround()
    {
        if (!onGround)
        {
            RaycastHit hit;
            float distance = 0.1f;
            Vector3 dir = new Vector3(0, -1);
            if (Physics.Raycast(transform.position, dir, out hit, distance))
            {
                onGround = true;
            }
            else
            {
                onGround = false;
            }
        }
    }

    public void ShootProjectile()
    {
        Vector3 projVelocity = Vector3.forward * proj_speed;
        

        if (proj != null)
        {
            anim.SetTrigger("Throw");
            aud.CandyShootSound();
            GameObject pr = Instantiate(proj, new Vector3(transform.position.x, transform.position.y + .35f, transform.position.z), transform.rotation);
            Rigidbody projRB = pr.GetComponent<Rigidbody>();
            projRB.AddRelativeForce(new Vector3(0, 0, proj_speed));
            //Debug.Log("RIGIDBODY VEL" + projRB.velocity);

            Destroy(pr, 5);

        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject pickup = other.gameObject;

        if (pickup.CompareTag("candy"))
        {
            candyCount++;
            pickup.SetActive(false);
            aud.InventorySelectCandySound();
            candyItem.UpdateCandyCount(candyCount);

        }

        if (pickup.CompareTag("veggie"))
        {
            veggieCount++;
            pickup.SetActive(false);
            aud.PickupVegetableSound();
            veggieItem.UpdateVeggieCount(veggieCount);


        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!onGround && collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }

        if (!isOnPlatform && collision.gameObject.CompareTag("Platform"))
        {
            gameObject.transform.parent.parent.parent = collision.transform;
            isOnPlatform = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (onGround && collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
         
        }

        if (isOnPlatform && collision.gameObject.CompareTag("Platform"))
        {
            gameObject.transform.parent.parent.parent = null;
            isOnPlatform = false;

        }
    }

    public float GetCandyCount()
    {
        return candyCount;
    }

    public void SetCandyCount(float newVal)
    {
        candyCount = newVal;
        candyItem.UpdateCandyCount(candyCount);
    }


    
}
