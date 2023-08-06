using UnityEngine;

namespace AlexzanderCowell
{
    public class SpawnSystem : MonoBehaviour
    {
        [SerializeField] private GameObject[] spawnPoint;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject character1;
        [SerializeField] private GameObject character2;
        private GameObject randomSpawn;
        private Vector3 _startingPosition;
        private bool spawnCharacter;

        void Start()
        {
            spawnCharacter = true;
        }

        private void Update()
        {
            if (GameModeSelection._moreThanOnePlayer)
            {
                Character1Spawn();
                Character2Spawn();
            }
            else
            {
                NormalSpawn();
            }
            
            if (PlayerMovement._controller.transform.position == _startingPosition)
            {
                transform.position = PlayerMovement._controller.transform.position;
            }
        }
        
        
        private void NormalSpawn()
        {
            if (spawnCharacter)
            {
                randomSpawn = spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)];
                Instantiate(player, randomSpawn.transform.position, Quaternion.identity);
                spawnCharacter = false;
            }
        }
        
        private void Character1Spawn()
        {
            if (spawnCharacter)
            {
                randomSpawn = spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)];
                Instantiate(character1, randomSpawn.transform.position, Quaternion.identity);
                spawnCharacter = false;
            }
        }
        
        private void Character2Spawn()
        {
            if (spawnCharacter)
            {
                randomSpawn = spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)];
                Instantiate(character2, randomSpawn.transform.position, Quaternion.identity);
                spawnCharacter = false;
            }
        }
        
    }
}
