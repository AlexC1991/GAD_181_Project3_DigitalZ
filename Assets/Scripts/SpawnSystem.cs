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
            GameModeSelection._moreThanOnePlayer = false;
            GameModeSelection._moreThanOnePlayerCheck2 = true;
        }

        private void FixedUpdate()
        {
            if (GameModeSelection._moreThanOnePlayer && !GameModeSelection._moreThanOnePlayerCheck2)
            {
                Character1Spawn();
            
            }
            else if (!GameModeSelection._moreThanOnePlayer && GameModeSelection._moreThanOnePlayerCheck2)
            {
                NormalSpawn();
            }
        }
        
        
        private void NormalSpawn()
        {
            if (spawnCharacter)
            {
                randomSpawn = spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)];
                Instantiate(player, randomSpawn.transform.position, Quaternion.identity);
                transform.position = PlayerMovement._controller.transform.position;
                spawnCharacter = false;
            }
        }
        
        private void Character1Spawn()
        {
            if (spawnCharacter)
            {
                randomSpawn = spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)];
                Instantiate(character1, randomSpawn.transform.position, Quaternion.identity);
                randomSpawn = spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)];
                Instantiate(character2, randomSpawn.transform.position, Quaternion.identity);
                transform.position = PlayerMovement._controller.transform.position;
                spawnCharacter = false;
            }
        }
        
        
    }
}
