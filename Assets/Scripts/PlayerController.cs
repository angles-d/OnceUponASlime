using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public HeartController hearts;
    public GameObject lose;
    public GameObject win;
    public AudioManager audioPlayer;
    public float heartCoolDown = 0.5f;
    float heartCDTimer;
    public bool playerIsDead = false;

    public Rigidbody rb;
    public float scale = 0.25f;
    private Vector3 scaleVec;
    public CameraController cam;

    public List<GameObject> dragonList = new List<GameObject>();
    public bool dragonDead = false;
    private Vector3 lastDragonPosition = new Vector3(0, 0, 0);
    public bool keyCollected = false;
    public GameObject key;
    public Animator anim;
    private int keyShown = 0;
    private GameObject KeyUI;
    public ParticleSystem confetti;
    bool playerWin = false;
    int size;

    // Start is called before the first frame update
    void Start()
    {
        lose.SetActive(false);
        win.SetActive(false);
        dragonList.AddRange(GameObject.FindGameObjectsWithTag("Dragon"));
        KeyUI = GameObject.FindGameObjectWithTag("KeyUI");
        KeyUI.SetActive(false);
        key = GameObject.Find("key");
        key.SetActive(false);

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        scaleVec = new Vector3(scale, scale, scale);
        size = hearts.numHearts;
        keyCollected = false;

        dragonDead = false;

        dragonDead = false;
        keyShown = 0;
        confetti.Pause();

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerIsDead)
        {
            CheckPlayerDead();

            if (anim.enabled == false)
            {
                anim.enabled = true;
            }

            if (heartCDTimer > 0)
            {
                heartCDTimer -= Time.deltaTime;
            }

            if (!dragonDead)
            {
                CheckFourDragonsDead();
            }
            if (dragonDead && keyShown == 0)
            {
                KeyUnlocked();
                keyShown = 1;
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            print("player hit by Fire");
            loseHeart();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("key"))
        {
            keyCollected = true;
            key.SetActive(!key.activeSelf);
            audioPlayer.KeyCollectedSound();
            KeyUI.SetActive(true);
        }
        else if (!playerWin&& other.CompareTag("Castle") && keyCollected)
        {
            playerWin = true;
            PlayerWin();
            
        }
        else if (other.CompareTag("river"))
        {
            print("river");
            hearts.isDead = true;
            audioPlayer.RiverSplashSound();
            audioPlayer.SlimeMeltSound();
            lose.SetActive(true);

        } else if (other.CompareTag("blob"))
        {
            audioPlayer.SlimeBlobSound();
            hearts.AddHeart();
            Destroy(other.gameObject);
            Grow();
            
        }
        else if (other.CompareTag("Spider"))
        {
            anim.SetInteger("DamageType", 2);
            anim.SetTrigger("Damage");
            
            loseHeart();
            print("player hit by Spider");  
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Tree"))
    //    {
    //        audioPlayer.TreeCollisionSound();
    //    }
    //}

    void PlayerWin()
    {
        confetti.Play();
        win.SetActive(true);
        audioPlayer.winSound();
        playerIsDead = true;
        rb.isKinematic = true;
        anim.SetTrigger("Win");
        
    }


    void Shrink()
    {
        if (size >= 1)
        {
            
            StartCoroutine(SlowShrink());
            size--;

            cam.slimeSize--;
            //cam.ChangeSize();
        }
           
    }

    IEnumerator SlowShrink()
    {
        Vector3 target = transform.parent.transform.localScale - scaleVec;
        Vector3 current = transform.parent.localScale;

        float elapsedTime = 0;
        float waitTime = 0.2f;
        audioPlayer.SlimeShrinkSound();
        while (elapsedTime < waitTime)
        {
            
            transform.parent.localScale = Vector3.Lerp(current, target, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }


    public void Grow()
    {
        if (size <= 6)
        {
            
            StartCoroutine(SlowGrow());
            size++;

            cam.slimeSize++;
            //cam.ChangeSize();
        }

    }

    IEnumerator SlowGrow()
    {
        Vector3 target = transform.parent.transform.localScale + scaleVec;
        Vector3 current = transform.parent.localScale;

        float elapsedTime = 0;
        float waitTime = 0.2f;

        audioPlayer.SlimeGrowSound();
        while (elapsedTime < waitTime)
        {
            transform.parent.localScale = Vector3.Lerp(current, target, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }

    void loseHeart()
    {
        if (heartCDTimer <= 0)
        {
            audioPlayer.LoseHeartSound();
            hearts.LoseHeart();
            Shrink();
            print("heart lost");
            heartCDTimer = heartCoolDown;
        }
    }

    void CheckPlayerDead()
    {
        if (hearts.isDead)
        {
            playerIsDead = true;
            anim.SetTrigger("Die");
        }
        
    }

    //trigggered by animation event in SlimeDie
    public void Die()
    {
        print("die");
        
        lose.SetActive(true);
        Debug.Log("finished animation, pausing");
        Time.timeScale = 0f;
        
    }

    void CheckFourDragonsDead()
    {
        int count = 0;
        for (int i = 0; i < dragonList.Count; i++)
        {
            if (dragonList[i].gameObject.GetComponent<DragonController>().isDead)
            {
                lastDragonPosition = dragonList[i].gameObject.transform.position;
                count++;
            }
        }
        if (count < 2)
        {
            return;
        }
        dragonDead = true;
    }

    private IEnumerator CallWait()
    {
        yield return new WaitForSeconds(5);
    }

    void KeyUnlocked()
    {
        Debug.Log("KeyUnlocked");
        key.transform.position = new Vector3(lastDragonPosition.x, lastDragonPosition.y + 2, lastDragonPosition.z);
        key.SetActive(true);
    }

}
