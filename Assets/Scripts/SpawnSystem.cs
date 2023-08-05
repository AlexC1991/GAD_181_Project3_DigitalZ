using System;
using UnityEngine;

namespace AlexzanderCowell
{
    public class SpawnSystem : MonoBehaviour
    {
        [SerializeField] private GameObject spawnPoint;
        private Vector3 _startingPosition;

        void Start()
        {
            // GameObject spawnP = GameObject.FindWithTag("SpawnPoint");
            // spawnPoint = spawnP;
            _startingPosition = spawnPoint.transform.position;
            if (_startingPosition != null && PlayerMovement._controller.transform.position != null)
            {
                PlayerMovement._controller.transform.position = _startingPosition;
            }
            
        }

        private void Update()
        {
            if (PlayerMovement._controller.transform.position == _startingPosition)
            {
                transform.position = PlayerMovement._controller.transform.position;
            }
        }
    }
}
