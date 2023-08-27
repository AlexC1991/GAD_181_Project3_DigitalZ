using UnityEngine;

namespace AlexzanderCowell
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip[] playerWalkingSounds;
        [SerializeField] private AudioClip[] playerRunningSounds;
        [SerializeField] private AudioClip playerDeathSound; //played upon players health reaching 0.

        [SerializeField] private AudioClip gunShotSound;
        [SerializeField] private AudioClip gunReloadSound; //played after gunshot sound.

        [SerializeField] private AudioClip[] zombieAmbienceSounds; //starts at radius 13, increase in volume till loudest at 1.
        [SerializeField] private AudioClip zombieDeathSound; //upon zombie health reaching 0. 
        [SerializeField] private AudioClip zombieAlertSound; //starts at radius 3.
        
        private float playingTime;

        public static AudioSource gameMusic; //plays game music.

        public static bool playGunSound;
        public static bool playReloadSound;
        public static bool playPlayerWalkingSound;
        public static bool playPlayerRunningSound;
        public static bool playZombieAmbienceSound;
        public static bool playZombieAlertSound;
        public static bool playZombieDeathSound;
        public static bool playPlayerDeathSound;

        void Start()
        {
            gameMusic = GetComponent<AudioSource>();
            playingTime = 1;
        }

        private void Update()
        {
            Debug.Log(playingTime);
            
            if (playGunSound)
            {
                gameMusic.PlayOneShot(gunShotSound);
                playGunSound = false;
            }

            if (playReloadSound)
            {
                PlayGunReloadSound();
                playReloadSound = false;
            }

            if (playPlayerWalkingSound)
            {
                PlayerWalkingSounds();
                playPlayerWalkingSound = false;
            }

            if (playPlayerRunningSound)
            {
                PlayPlayerRunningSounds();
                playPlayerRunningSound = false;
            }

            if (playZombieAmbienceSound)
            {
                PlayZombieAmbienceSound();
                playZombieAmbienceSound = false;
            }

            if (playZombieAlertSound)
            {
                PlayZombieAlert();
                playZombieAlertSound = false;
            }

            if (playZombieDeathSound)
            {
                PlayZombieDeathSound();
                playZombieDeathSound = false;
            }

            if (playPlayerDeathSound)
            {
                HandlePlayerDeath();
                playPlayerDeathSound = false;
            }
        }

        private void PlayZombieAmbienceSound()
        {
            float distanceToEnemy = Vector3.Distance(ZombieAIScript.zombieTransform.position, PlayerMovement._controller.transform.position);
            float maxAudibleDistance = 13f;
            float volumeFactor = 1f - Mathf.Clamp01(distanceToEnemy / maxAudibleDistance);
                  
            AudioClip clip = zombieAmbienceSounds[Random.Range(0, zombieAmbienceSounds.Length)];
            gameMusic.PlayOneShot(clip, volumeFactor);
        }

        private void PlayZombieAlert()
        {
            float distanceToEnemy = Vector3.Distance(ZombieAIScript.zombieTransform.position, PlayerMovement._controller.transform.position);
            float maxAudibleDistance = 3f;
            float volumeFactor = 1f - Mathf.Clamp01(distanceToEnemy / maxAudibleDistance);
            
            gameMusic.PlayOneShot(zombieAlertSound, volumeFactor);
        }

        private void PlayZombieDeathSound()
        {
                gameMusic.PlayOneShot(zombieDeathSound);
        }

        private void PlayerWalkingSounds()
        {
                AudioClip clip = playerWalkingSounds[Random.Range(0, playerWalkingSounds.Length)];
                gameMusic.PlayOneShot(clip);
        }

        private void PlayPlayerRunningSounds()
        {
                AudioClip clip = playerRunningSounds[Random.Range(0, playerRunningSounds.Length)];
                gameMusic.PlayOneShot(clip);
        }

        private void HandlePlayerDeath()
        {
                gameMusic.PlayOneShot(playerDeathSound);
        }

        private void PlayGunShotSound()
        {
            
        }

        private void PlayGunReloadSound()
        {
            gameMusic.PlayOneShot(gunReloadSound);
        }
    }
}