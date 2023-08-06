using System;
using UnityEngine;

namespace AlexzanderCowell
{
    public class SpawnSystem : MonoBehaviour
    {
        [SerializeField] private GameObject[] spawnPoint;
        [SerializeField] private GameObject player;
        private GameObject randomSpawn;
        private Vector3 _startingPosition;

        void Start()
        {
            // GameObject spawnP = GameObject.FindWithTag("SpawnPoint");
            // spawnPoint = spawnP;
            randomSpawn = spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)];
            Instantiate(player, randomSpawn.transform.position, Quaternion.identity);
            
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
