using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public AudioSource playerSounds;
    public AudioSource gunSounds;
    public AudioSource zombieSounds;
    public AudioSource backgroundMusic;

    public AudioClip[] playerWalkingSounds;
    public AudioClip[] playerRunningSounds;
    public AudioClip playerDeathSound; //played upon players health reaching 0.

    public AudioClip gunShotSound;
    public AudioClip gunReloadSound; //played after gunshot sound.

    public AudioClip[] zombieAmbienceSounds; //starts at radius 13, increase in volume till loudest at 1.
    public AudioClip zombieDeathSound; //upon zombie health reaching 0. 
    public AudioClip zombieAlertSound; //starts at radius 3.

    public AudioClip menuMusic; //played after a brief delay on menu screen.
    public AudioClip gameMusic; //played after a brief delay upon entering map/scene.
    public AudioClip loadSound; //played on teleport loads. (If included).

    private Transform _controller;

    void Start()
    {
        StartCoroutine(PlayDelayedGameMusic());
    }

    IEnumerator PlayDelayedGameMusic()
    {
        yield return new WaitForSeconds(0.1f);
        PlayGameMusic();
    }

    public void PlayGameMusic()
    {
        backgroundMusic.clip = gameMusic;
        backgroundMusic.Play();
    }


    public void PlayZombieAmbienceSound(Vector3 enemyPosition)
    {
        float distanceToEnemy = Vector3.Distance(enemyPosition, _controller.position);
        float maxAudibleDistance = 13f;
        float volumeFactor = 1f - Mathf.Clamp01(distanceToEnemy / maxAudibleDistance);

        if (zombieAmbienceSounds.Length > 0)
        {
            AudioClip clip = zombieAmbienceSounds[Random.Range(0, zombieAmbienceSounds.Length)];
            zombieSounds.PlayOneShot(clip, volumeFactor);
        }
    }

    public void PlayZombieAlert(Vector3 enemyPosition)
    {
        float distanceToEnemy = Vector3.Distance(enemyPosition, _controller.position);
        float maxAudibleDistance = 3f;
        float volumeFactor = 1f - Mathf.Clamp01(distanceToEnemy / maxAudibleDistance);

        if (zombieAlertSound != null)
        {
            zombieSounds.PlayOneShot(zombieAlertSound, volumeFactor);
        }
    }

    public void HandlePlayerMovement(bool isRunning)
    {
        if (isRunning)
        {
            PlayPlayerRunningSounds();
        }
        else
        {
            PlayPlayerWalkingSounds();
        }
    }

    public void PlayPlayerRunningSounds()
    {
        if (playerRunningSounds.Length > 0)
        {
            AudioClip clip = playerRunningSounds[Random.Range(0, playerRunningSounds.Length)];
            playerSounds.PlayOneShot(clip);
        }
    }

    public void PlayPlayerWalkingSounds()
    {
        if (playerWalkingSounds.Length > 0)
        {
            AudioClip clip = playerWalkingSounds[Random.Range(0, playerWalkingSounds.Length)];
            playerSounds.PlayOneShot(clip);
        }
    }

    //public void HandlePlayerDeath()
    //{
    //    PlayPlayerDeathSound();
    //}

    public void HandleGunShot()
    {
        PlayGunShotSound(); 
        PlayGunReloadSound(); 
    }

    private void PlayGunShotSound()
    {
        gunSounds.PlayOneShot(gunShotSound);
    }

    private void PlayGunReloadSound()
    {
        gunSounds.PlayOneShot(gunReloadSound);
    }
}

