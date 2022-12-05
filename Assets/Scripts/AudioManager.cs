using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    //public static AudioManager Instance { get; private set; }

    public AudioClip[] audioClips;
    private Dictionary<string, AudioClip> aud = new Dictionary<string, AudioClip>();

    public AudioClip[] candyPickSounds;
    public AudioClip[] candyShootSounds;

    public AudioClip[] dragonStepSounds;
    public AudioClip[] dragonRoarSounds;

    public AudioClip[] spiderDamageSounds;

    private AudioSource audioSource;

    void Awake()
    {
        //if (Instance != null && Instance != this)
        //{
        //    Destroy(this);
        //}
        //else
        //{
        //    Instance = this;
        //}

        foreach (AudioClip sound in audioClips)
        {
            name = sound.name;
            aud.Add(name, sound);

        }

        audioSource = GetComponent<AudioSource>();
    }

    public void SlimeBounceSound(Vector3 position)
    {
        audioSource.PlayOneShot(aud["Slime_Slide_Loop"]);
    }

    public void SlimeShrinkSound(Vector3 position)
    {
        audioSource.PlayOneShot(aud["Slime_Shrink"]);
    }
    public void SlimeGrowSound()
    {
        audioSource.PlayOneShot(aud["Slime_Grow"]);
    }

    public void SlimeMeltSound()
    {
        audioSource.PlayOneShot(aud["Slime_Melt"]);
    }

    public void SlimeBurnSound()
    {
        audioSource.PlayOneShot(aud["Slime_Burn"]);
    }

    public void PickupCandySound()
    {
        int randInd = Random.Range(0,candyPickSounds.Length);
        audioSource.PlayOneShot(candyPickSounds[randInd]);
    }

    public void CandyShootSound()
    {
        int randInd = Random.Range(0, candyShootSounds.Length);
        audioSource.PlayOneShot(candyShootSounds[randInd]);
    }

    public void PickupVegetableSound()
    {
        audioSource.PlayOneShot(aud["Select_Veg"]);
    }

    public void DragonRoarSound(Vector3 position)
    {
        int randInd = Random.Range(0, dragonRoarSounds.Length);
        audioSource.PlayOneShot(dragonRoarSounds[randInd]);
    }

    public void DragonStepSound(Vector3 position)
    {
        int randInd = Random.Range(0, dragonStepSounds.Length);
        AudioSource.PlayClipAtPoint(dragonStepSounds[randInd], position);
    }

    public void DragonFireSound(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(aud["Dragon_Fire_01"], position);
    }

    public void BunnyBounceSound(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(aud["Bunny_Bounce"], position);
    }

    public void InventorySelectVegSound()
    {
        audioSource.PlayOneShot(aud["Select_Veg"]);
    }

    public void InventorySelectCandySound()
    {
        audioSource.PlayOneShot(aud["Candy_Inv_Select"]);
    }

    public void InventoryOpenSound()
    {
        audioSource.PlayOneShot(aud["Inv_Open"]);
    }

    public void InventoryCloseSound()
    {
        print("Close inv sound");
        audioSource.PlayOneShot(aud["Inv_Close"]);
    }

    public void TimerTickSound()
    {
        audioSource.PlayOneShot(aud["Timer_Tick_Loop"]);
    }

    public void TimerAlarmSound()
    {
        audioSource.PlayOneShot(aud["Timer_Alarm"]);
    }

    public void TimerAlmostUpSound()
    {
        audioSource.PlayOneShot(aud["Timer_AlmostUp_Loop"]);
    }

    public void TreeCollisionSound()
    {
        audioSource.PlayOneShot(aud["Leaves"]);
    }

    public void LoseHeartSound()
    {
        audioSource.PlayOneShot(aud["Lose Heart"]);
    }
    public void SlimeBlobSound()
    {
        audioSource.PlayOneShot(aud["Slime Blob"]);
    }

    public void RiverSplashSound()
    {
        audioSource.PlayOneShot(aud["water_splash_sound"]);
    }

    public void KeyCollectedSound()
    {
        audioSource.PlayOneShot(aud["KeyCollected"]);
    }
    public void SlimeJumpSound()
    {
        audioSource.PlayOneShot(aud["Bunny_Bounce"]);
    }

    public void winSound() {

        audioSource.PlayOneShot(aud["winSound"]);

    }

    public void SpiderAttackSound()
    {
        audioSource.PlayOneShot(aud["Spider_Attack"]);
    }

    public void SpiderSquishSound()
    {
        audioSource.PlayOneShot(aud["Spider_Death_Squish"]);
    }

    public void SpiderDeathSound()
    {
        audioSource.PlayOneShot(aud["Spider_Death"]);
    }

    public void SpiderDamageSound()
    {
        int randInd = Random.Range(0, spiderDamageSounds.Length);
        audioSource.PlayOneShot(spiderDamageSounds[randInd]);
    }
}
