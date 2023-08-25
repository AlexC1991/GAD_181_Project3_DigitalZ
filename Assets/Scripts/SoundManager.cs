using System.Collections;
using UnityEngine;

namespace AlexzanderCowell
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource playerSounds;
        private AudioSource gunSounds;
        private AudioSource zombieSounds;

        private AudioClip[] playerWalkingSounds;
        private AudioClip[] playerRunningSounds;
        private AudioClip playerDeathSound; //played upon players health reaching 0.

        private AudioClip gunShotSound;
        private AudioClip gunReloadSound; //played after gunshot sound.

        private AudioClip[] zombieAmbienceSounds; //starts at radius 13, increase in volume till loudest at 1.
        private AudioClip zombieDeathSound; //upon zombie health reaching 0. 
        private AudioClip zombieAlertSound; //starts at radius 3.

        private AudioSource gameMusic; //plays game music.
        private float delayInSeconds = 0.5f; //initiates delay. Intended for use with gameMusic.

        private Transform _controller;
        public static SoundManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        void Start()
        {
            gameMusic = GetComponent<AudioSource>();
            Invoke("gameMusic", delayInSeconds);
        }

        void PlayMusic()
        {
            gameMusic.Play();
        }

        void PlayZombieAmbienceSound(Vector3 enemyPosition)
        {
            float distanceToEnemy = Vector3.Distance(enemyPosition, _controller.position);
            float maxAudibleDistance = 13f;
            float volumeFactor = 1f - Mathf.Clamp01(distanceToEnemy / maxAudibleDistance);

            //    if (ZombieAIScript.visionRadius)
            //    {
            //        AudioClip clip = zombieAmbienceSounds[Random.Range(0, zombieAmbienceSounds.Length)];
            //        zombieSounds.PlayOneShot(clip, volumeFactor);
            //    }
        }

        void PlayZombieAlert(Vector3 enemyPosition)
        {
            float distanceToEnemy = Vector3.Distance(enemyPosition, _controller.position);
            float maxAudibleDistance = 3f;
            float volumeFactor = 1f - Mathf.Clamp01(distanceToEnemy / maxAudibleDistance);

            //    if (ZombieAIScript.attackRadius)
            //    {
            //        zombieSounds.PlayOneShot(zombieAlertSound, volumeFactor);
            //    }
        }

        void PlayZombieDeathSound()
        {
            if (ZombieHealth._isDead)
            {
                zombieSounds.PlayOneShot(zombieDeathSound);
            }
        }

        void HandlePlayerMovement()
        {
            if (PlayerMovement._runFaster)
            {
                PlayPlayerRunningSounds();
            }
            else
            {
                PlayPlayerWalkingSounds();
            }

            if (PlayerOneScript._runFaster)
            {
                PlayPlayerRunningSounds();
            }
            else
            {
                PlayPlayerWalkingSounds();
            }

            if (TwoPlayerMovementScript._runFaster)
            {
                PlayPlayerRunningSounds();
            }
            else
            {
                PlayPlayerWalkingSounds();
            }
        }

        void PlayPlayerRunningSounds()
        {
            if (playerRunningSounds.Length > 0)
            {
                AudioClip clip = playerRunningSounds[Random.Range(0, playerRunningSounds.Length)];
                playerSounds.PlayOneShot(clip);
            }
        }

        void PlayPlayerWalkingSounds()
        {
            if (playerWalkingSounds.Length > 0)
            {
                AudioClip clip = playerWalkingSounds[Random.Range(0, playerWalkingSounds.Length)];
                playerSounds.PlayOneShot(clip);
            }
        }

        //public void HandlePlayerDeath()
        //{
        //    if (PlayerHealth._isDead)
        //    {
        //        PlayPlayerDeathSound();
        //    }
        //}

        void HandleGunShot()
        {
            if (GunRayCasting._isShooting)
            {
                PlayGunShotSound();
                PlayGunReloadSound();
            }
        }

        void PlayGunShotSound()
        {
            gunSounds.PlayOneShot(gunShotSound);
        }

        void PlayGunReloadSound()
        {
            gunSounds.PlayOneShot(gunReloadSound);
        }
    }
}