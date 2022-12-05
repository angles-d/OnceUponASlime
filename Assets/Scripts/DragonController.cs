using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonController : MonoBehaviour
{
    public float speed = 6f;
    public GameObject fire;
    public float dragonRadius = 4;
    public bool isChasing = false;
    public GameObject mouth;
    public bool breatheFire = false;
    public AudioManager aud;
    public bool isDead = false;
    float waitToDisapear = 2;

    public Collider territory;

    private GameObject player;
    private Transform playerTransform;
    public ParticleSystem fireParticle;
    public float fireTime = 3; //how long fire lasts in seconds
    public float timer;
    private Transform dragonMouth;
    public Animator anim;

    public Vector3 target;

    private float sqrdDist;

    
    public bool turnAround = false;
    public bool roar = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Slime Princess");
        playerTransform = player.GetComponent<Transform>();
        fireParticle = fire.GetComponent<ParticleSystem>();
        timer = fireTime;
        dragonMouth = mouth.GetComponent<Transform>();
        anim = GetComponent<Animator>();
        sqrdDist = dragonRadius * dragonRadius;
        SetNewPosition();
        anim.SetTrigger("Walk");


    }

    private void Update()
    {
        if (isDead)
        {
            CheckDie();
            
        }
        if (!isDead)
        {
            
            if (!roar & !turnAround)
            {
                if (isChasing)
                {
                    Chase();
                }
                else
                {
                    Wander();
                }
            }

            if (breatheFire)
            {
                if (timer > 0)
                {
                    dragonMouth.LookAt(playerTransform);
                    fireParticle.transform.position = dragonMouth.position;
                    fireParticle.transform.rotation = dragonMouth.rotation;
                    timer -= Time.deltaTime;
                }
                else
                {
                    fireParticle.Stop();
                    breatheFire = false;
                    timer = fireTime;
                    
                    
                }

            }
        }

       
    }

    public void BreatheFire()
    {
        if (!isDead && !breatheFire)
        {
            //Debug.Log("fire start");
            fireParticle.Play();
            fireParticle.transform.position = dragonMouth.position;
            fireParticle.transform.rotation = dragonMouth.rotation;
            if (aud != null) {aud.DragonFireSound(dragonMouth.position); }
            aud.DragonRoarSound(transform.position);
            breatheFire = true;
        }

    }


    public void Chase()
    {

        Vector3 lookVec = playerTransform.position - transform.position;
        float dist = lookVec.sqrMagnitude;
        if (dist > sqrdDist)
        {
            lookVec.y = 0;
            Quaternion rot = Quaternion.LookRotation(lookVec);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);

            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    public void Wander()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            SetNewPosition();
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void SetNewPosition()
    {
        target = GetRandomPointInBounds(territory.bounds);
        Vector3 look = new Vector3(target.x, transform.position.y, target.z);
        transform.LookAt(look);
    }
   

    public Vector3 GetRandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z));

    }


    public void Die()
    {
        anim.SetTrigger("Die");
        fire.SetActive(false);
        isDead = true;
    }

   

    public void CheckDie()
    {
        AnimatorStateInfo cur = anim.GetCurrentAnimatorStateInfo(0);
        if (cur.IsName("Die") && cur.normalizedTime > 1 && !anim.IsInTransition(0))
        {
            CheckDisapear();
        }
    }

   void CheckDisapear()
    {
        if (waitToDisapear <= 0)
        {
            territory.gameObject.SetActive(false);
            gameObject.SetActive(false);
        } else
        {
            waitToDisapear -= Time.deltaTime;
        }
    }

    public void Roar()
    {
        Vector3 lookVec = playerTransform.position - transform.position;
        lookVec.y = 0;
        Quaternion rot = Quaternion.LookRotation(lookVec);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);

        roar = true;
        
        anim.SetTrigger("Scream");
        anim.ResetTrigger("Walk");
        
    }

    public void PlayRoar()
    {
       aud.DragonRoarSound(transform.position);
    }

    public IEnumerator SlowTurn()
    {
        if (!roar)
        {
            print("Turn start");
            anim.SetTrigger("Walk");
            anim.ResetTrigger("Run");
            yield return new WaitForSeconds(0.6f);

            Vector3 look = new Vector3(target.x, transform.position.y, target.z);
            transform.LookAt(look);
            turnAround = false;
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }

    }

    public void RoarDone()
    {
        roar = false;
    }

    


}


