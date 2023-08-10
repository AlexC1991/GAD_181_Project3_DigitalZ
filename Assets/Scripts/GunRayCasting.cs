using UnityEngine;

namespace AlexzanderCowell
{
    
    public class GunRayCasting : MonoBehaviour
    {
        [Header("More Than One Player Controls")]
        
        [SerializeField] private KeyCode shootGunKey;

        [Header("Gun Characteristics")] [SerializeField]
        public static float _damage = 10f;
        [SerializeField] private ParticleSystem muzzleFlash;

        [Header("Raycast Properties")] [SerializeField]
        private float _range = 35f; 
        public static string hitObjectName;

        [SerializeField] private Transform gunEnd;
        private GameObject zombieEnemy;

        [Header("Internal Properties")] private Camera _mainCamera;
        private RaycastHit _hit;
        public static bool _isShooting;
        private bool hitZombie;
        private float flashTimer = 0.2f;
        private float originalFlashTimer;


        private void Start()
        {
            originalFlashTimer = flashTimer;
            _mainCamera = Camera.main;
            zombieEnemy = GameObject.FindWithTag("Zombie");
        }

        private void Update()
        {
            if (GameModeSelection._moreThanOnePlayer && !GameModeSelection._moreThanOnePlayerCheck2)
            {
                MoreThanOnePlayerControls();
            }
            else if (!GameModeSelection._moreThanOnePlayer && GameModeSelection._moreThanOnePlayerCheck2)
            {
                NormalControls();
            }
            
            if (_isShooting)
            {
                muzzleFlash.Play();
                ShootGun();
                flashTimer -= 0.2f * Time.deltaTime;
            }

            if (flashTimer == 0 || (flashTimer < 0.1f))
            {
                muzzleFlash.Pause();
                _isShooting = false;
                muzzleFlash.Clear();
                flashTimer = originalFlashTimer;

            }

            Debug.DrawLine(gunEnd.position, _hit.point, Color.red, 1.5f);

        }

        private void NormalControls()
        {
            if (Input.GetKeyDown(shootGunKey))
            {
                _isShooting = true;
            }
        }

        private void MoreThanOnePlayerControls()
        {
            if (Input.GetKeyDown(shootGunKey))
            {
                _isShooting = true;
            }
        }

        private void ShootGun()
        {
            if (Physics.Raycast(gunEnd.position, gunEnd.forward, out _hit, _range))
            {
                hitObjectName = _hit.transform.name;
            }

        }
    }
}
