using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderController: Controller 
{
    Animator anim;
    public int min = -30;
    public int max = 30;
    int lives;
    public bool dead = false;
    public bool chasingPlayer = false;


    GameObject player;
    public GameObject hitBox;
    public GameObject bodyCollider;
    public GameObject deadCollider;
    public GameObject legCol1;
    public GameObject legCol2;

    public GameObject hearts;
    private EnemyHeartController hc;

    Vector3 target;
    public SpiderState state = SpiderState.WANDER;
    float speed;
    BoxCollider attack_trigger;
    NavMeshAgent agent;

    public float coolDown = 0.75f;
    float cdTimer;

    public AudioManager aud;

    public enum SpiderState
    {
        WANDER,
        ATTACK,
        HIT,
        DEAD
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = GetComponentInChildren<Animator>();
        target = randomTarget(min, max);
        hc = hearts.GetComponent<EnemyHeartController>();
        lives = hc.numHearts;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target;
        speed = agent.speed;
        attack_trigger = GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        
        switch (state)
        {
            case SpiderState.WANDER:
                float dist = (player.transform.position - transform.position).sqrMagnitude;
                if (dist < 100)
                {
                    agent.destination = new Vector3(player.transform.position.x, 0, player.transform.position.z);
                    chasingPlayer = true;
                }
                if (!chasingPlayer)
                {
                    CheckReachTarget();
                }
                break;
            case SpiderState.ATTACK:
                AttackToWander();
                break;
            case SpiderState.HIT:
                HitToWander();
                break;
            case SpiderState.DEAD:
                CheckDead();
                break;

        }

        if (cdTimer > 0)
        {
            cdTimer -= Time.deltaTime;
        }


    }

    void CheckReachTarget()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            target = randomTarget(min, max);
            agent.destination = target;
        }
    }

    public override void Hit()
    {
        if (state != SpiderState.DEAD)
        {
            Debug.Log("recieved hit");
            agent.speed = 0;
            hc.HeartLost();

            
            if (lives <= 1)
            {
                aud.SpiderDeathSound();
                state = SpiderState.DEAD;
                anim.SetTrigger("Die");
            }
            else
            {
                aud.SpiderDamageSound();
                anim.SetTrigger("Hit");
                lives--;
                state = SpiderState.HIT;
                cdTimer = coolDown;
            }
        }
       
    }


    void HitToWander()
    {
        AnimatorStateInfo cur = anim.GetCurrentAnimatorStateInfo(0);
        if (cur.IsName("Walk"))
        {
            agent.speed = speed;
            state = SpiderState.WANDER;
        }
       
    }

    void AttackToWander()
    {
        AnimatorStateInfo cur = anim.GetCurrentAnimatorStateInfo(0);
        if (cur.IsName("Walk"))
        {
            agent.speed = speed;
            state = SpiderState.WANDER;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (state == SpiderState.WANDER && other.CompareTag("Player"))
        {
            aud.SpiderAttackSound();
            state = SpiderState.ATTACK;
            Debug.Log("spider attack");
            agent.speed = 0;
            anim.SetTrigger("Attack");
        }

        if (other.gameObject.CompareTag("projectile"))
        {
            Hit();
        }
    }


    private void CheckDead()
    {

        AnimatorStateInfo cur = anim.GetCurrentAnimatorStateInfo(0);
        if (cur.IsName("Death") && cur.normalizedTime > 1 && !anim.IsInTransition(0))
        {
            agent.speed = 0;
            hitBox.SetActive(false);
            legCol1.SetActive(false);
            legCol2.SetActive(false);
            deadCollider.SetActive(true);
            deadCollider.transform.position = transform.position;
            bodyCollider.SetActive(false);
            agent.enabled = false;
            anim.enabled = false;
            attack_trigger.enabled = false;
            this.enabled = false;
        }
    }

    Vector3 randomTarget(float minVal, float maxVal)
    {
        return new Vector3(Random.Range(minVal, maxVal), 0,  Random.Range(minVal, maxVal));
    }
}
