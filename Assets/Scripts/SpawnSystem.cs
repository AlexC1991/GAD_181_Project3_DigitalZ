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

        private void Start()
        {
            spawnCharacter = true;
            GameModeSelection._moreThanOnePlayer = false;
            GameModeSelection._moreThanOnePlayerCheck2 = true;
        }

        private void FixedUpdate()
        {
            if (GameModeSelection._moreThanOnePlayer && !GameModeSelection._moreThanOnePlayerCheck2)
            {
                randomSpawn = spawnPoint[Random.Range(0, spawnPoint.Length)];
                Character1Spawn();
            }
            else if (!GameModeSelection._moreThanOnePlayer && GameModeSelection._moreThanOnePlayerCheck2)
            {
                randomSpawn = spawnPoint[Random.Range(0, spawnPoint.Length)];
                NormalSpawn();
            }
        }
        
        
        private void NormalSpawn()
        {
            if (spawnCharacter)
            {
                Instantiate(player, randomSpawn.transform.position, Quaternion.identity);
                /*transform.position = PlayerMovement._controller.transform.position;*/
                spawnCharacter = false;
            }
        }
        
        private void Character1Spawn()
        {
            if (spawnCharacter)
            {
                
                Instantiate(character1, randomSpawn.transform.position, Quaternion.identity);
                Instantiate(character2, randomSpawn.transform.position, Quaternion.identity);
                /*transform.position = PlayerMovement._controller.transform.position;*/
                spawnCharacter = false;
            }
        }
        
        
    }
}
