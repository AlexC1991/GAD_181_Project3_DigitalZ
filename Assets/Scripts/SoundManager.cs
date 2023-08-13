using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //public AudioSource playerSounds;
    //public AudioSource gunSounds;
    //public AudioSource zombieSounds;
    //public AudioSource backgroundMusic;

    //public AudioClip[] playerWalkingSounds;
    //public AudioClip[] playerRunningSounds;
    //public AudioClip playerDeathSound; //played upon players health reaching 0.

    //public AudioClip gunShotSound; 
    //public AudioClip gunReloadSound; //played after gunshot sound.

    //public AudioClip[] zombieAmbienceSounds; //starts at radius 13, increase in volume till loudest at 1.
    //public AudioClip zombieDeathSound; //upon zombie health reaching 0. 
    //public AudioClip zombieAlertSound; //starts at radius 3.

    //public AudioClip menuMusic; //played after a brief delay on menu screen.
    //public AudioClip gameMusic; //played after a brief delay upon entering map/scene.
    //public AudioClip loadSound; //played on teleport loads. (If included).

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    //void Start()
    //{
    //    StartCoroutine(PlayDelayedMenuMusic());
    //    StartCoroutine(PlayDelayedGameMusic());
    //}

    //IEnumerator PlayDelayedGameMusic()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    PlayGameMusic();
    //}

    //public void PlayEnemyAmbienceSound(Vector3 enemyPosition)
    //{
    //    float distanceToEnemy = Vector3.Distance(enemyPosition, playerTransform.position);
    //    float maxAudibleDistance = 13f;
    //    float volumeFactor = 1f - Mathf.Clamp01(distanceToEnemy / maxAudibleDistance);

    //    if (enemyAmbienceSounds.Length > 0)
    //    {
    //        AudioClip clip = enemyAmbienceSounds[Random.Range(0, enemyAmbienceSounds.Length)];
    //        enemySoundsAudioSource.PlayOneShot(clip, volumeFactor);
    //    }
    //}

    // public void PlayEnemyAttack(Vector3 enemyPosition)
    //{
    //    float distanceToEnemy = Vector3.Distance(enemyPosition, playerTransform.position);
    //    float maxAudibleDistance = 3f;
    //    float volumeFactor = 1f - Mathf.Clamp01(distanceToEnemy / maxAudibleDistance);

    //    if (enemyAttackSound != null)
    //    {
    //        enemySoundsAudioSource.PlayOneShot(enemyAttackSound, volumeFactor);
    //    }
    //}

    //public void HandlePlayerMovement(bool isRunning)
    //{
    //    if (isRunning)
    //    {
    //        PlayRandomPlayerRunningSound();
    //    }
    //    else
    //    {
    //        PlayRandomPlayerWalkingSound();
    //    }
    //}

    //public void HandlePlayerDeath()
    //{
    //    PlayPlayerDeathSound();
    //}

    //public void HandleGunShot()
    //{
    //    PlayGunShotSound();
    //    PlayGunReloadSound(); 
    //}
}
