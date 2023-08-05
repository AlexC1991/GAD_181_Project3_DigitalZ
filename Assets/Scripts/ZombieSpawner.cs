using System;
using UnityEngine;

namespace AlexzanderCowell
{
    public class ZombieSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] zombiePrefab;
        [SerializeField] private float spawnRadius;
        [SerializeField] private GameObject[] spawnPoints;
        private Vector3 _spawnPosition;
        private GameObject _zombie;
        [SerializeField] float timerValue = 1;
        private float timer;
        private int randomZombie;
        private int randomSpawnPoint;
        private int _zombieCount;
        private int _zombieNumber;
        [SerializeField] int _maxZombies = 150;
        [SerializeField] private GameObject zombieContainer;

        private void Start()
        {
            timer = timerValue;
        }

        private void Update()
        {
            
            // Starts a timer every 5 seconds and when it gets to 0 it will reset back to 5.
            if (_zombieCount < _maxZombies)
            {
                timer -= 0.8f * Time.deltaTime;
            }
            
            if (timer < 0.2f && _zombieCount < _maxZombies)
            {
                // Randomly selects a spawn point from the array.       
                randomSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Length);
                // Randomly selects a zombie from the array.
                randomZombie = UnityEngine.Random.Range(0, zombiePrefab.Length);
                // Sets the spawn position to the random spawn point & spawns a zombie at that random position and if there is a zombie in that random spawn point to not spawn a zombie.
                _spawnPosition = spawnPoints[randomSpawnPoint].transform.position;
                _zombie = Instantiate(zombiePrefab[randomZombie], _spawnPosition, Quaternion.identity);
                // Sets a random zombie name to the zombie
                _zombie.name = "Zombie" + _zombieNumber;
                _zombie.transform.parent = zombieContainer.transform;
                _zombieNumber += 1;
                _zombieCount += 1;
                timer = timerValue;
            }
            
            if (_zombieCount >= _maxZombies)
            {
                timer = timerValue;
            }
        }
    }
}
