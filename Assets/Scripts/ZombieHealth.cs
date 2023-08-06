using System;
using UnityEngine;

namespace AlexzanderCowell
{
    public class ZombieHealth : MonoBehaviour
    {

        [SerializeField] private float _health = 50f;
        private bool _isDead;
        private Animator _animator;
        private bool takeDamage;
        
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.SetBool("isDead", false);
            takeDamage = false;
        }

        private void Update()
        {
            Death();
            
            if (GunRayCasting.hitObjectName == name && (GunRayCasting._isShooting))
            {
                takeDamage = true;
            }

            if (takeDamage)
            {
                TakingDamage();
                takeDamage = false;
            }
        }

        private void TakingDamage()
        {
            _health -= GunRayCasting._damage;
        }
        
        private void Death()
        {
            if (_health <= 0)
            {
                _isDead = true;
                _animator.SetBool("isDead", true);
                Destroy(gameObject, 3f);
            }
        }
    }
}
