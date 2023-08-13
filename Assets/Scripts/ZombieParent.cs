using System;
using UnityEngine;

namespace AlexzanderCowell
{
    public class ZombieParent : MonoBehaviour
    {
        private void Update()
        {
            if (transform.childCount < 1)
                Destroy(gameObject);
        }
    }
}
