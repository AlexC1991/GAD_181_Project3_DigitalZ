using System;
using UnityEngine;
using UnityEngine.AI;

namespace AlexzanderCowell
{
    public class ZombieAIScript : MonoBehaviour
    {
        
        private NavMeshAgent _agent;
        private float zombieRunSpeed;
        private float zombieWalkSpeed;
        [SerializeField] private float visionRadius = 10;
        [SerializeField] private float chaseRadius = 10;
        [SerializeField] private float attackRadius = 2;
        private float _randomDistance;
        [SerializeField] private Animator animator;
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            // zombie will choose a random direction to move in when it spawns using nav mesh.
            _agent.SetDestination(transform.position + new Vector3(UnityEngine.Random.Range(-200, 200), 0, UnityEngine.Random.Range(-200, 200)));
            zombieRunSpeed = UnityEngine.Random.Range(6, 12);
            zombieWalkSpeed = UnityEngine.Random.Range(1, 4);
            _randomDistance = UnityEngine.Random.Range(10, 200);
        }

        private void Update()
        {
            // Make zombie move around the map using nav mesh & walk speed than changes direction after 1 min of walking in one direction.
            
            if ((Vector3.Distance(transform.position, PlayerMovement._controller.transform.position) > chaseRadius &&
                 Vector3.Distance(transform.position, PlayerMovement._controller.transform.position) > attackRadius))
            {
                _agent.speed = zombieWalkSpeed;
                animator.SetBool("SeePlayer", false);
                animator.SetBool("AttackPlayer", false);
            }

                if (_agent.remainingDistance < _randomDistance)
            {
                _agent.SetDestination(transform.position + new Vector3(UnityEngine.Random.Range(-200, 200), 0, UnityEngine.Random.Range(-200, 200)));
            }
            
            // If the player character is within the zombie's vision, the zombie will chase the player and look at the player as well.
            if (Vector3.Distance(transform.position, PlayerMovement._controller.transform.position) < chaseRadius)
            {
                animator.SetBool("SeePlayer", true);
                zombieRunSpeed = Mathf.Lerp(zombieRunSpeed, zombieWalkSpeed, Time.deltaTime);
                _agent.speed = zombieRunSpeed;
                _agent.SetDestination(PlayerMovement._controller.transform.position);
                transform.LookAt(PlayerMovement._controller.transform.position);
            }
            else if (Vector3.Distance(transform.position, PlayerMovement._controller.transform.position) > chaseRadius &&
                     Vector3.Distance(transform.position, PlayerMovement._controller.transform.position) > attackRadius)
            {
                animator.SetBool("SeePlayer", false);
                animator.SetBool("AttackPlayer", false);
            }
            
            // If the zombie is with in the attack radius of the player, the zombie will stop moving and attack the player.
            if (Vector3.Distance(transform.position, PlayerMovement._controller.transform.position) < attackRadius)
            {
                animator.SetBool("AttackPlayer", true);
                animator.SetBool("SeePlayer", false);
                _agent.speed = 0;
                transform.LookAt(PlayerMovement._controller.transform.position);
            }
            else if (Vector3.Distance(transform.position, PlayerMovement._controller.transform.position) > attackRadius && Vector3.Distance(transform.position, PlayerMovement._controller.transform.position) < chaseRadius)
            {
                animator.SetBool("AttackPlayer", false);
                animator.SetBool("SeePlayer", true);
            }

            if (Vector3.Distance(transform.position, PlayerMovement._controller.transform.position) < visionRadius)
            {
                transform.LookAt(PlayerMovement._controller.transform.position);
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (_agent == enabled)
            {
                // creates a on draw gizmo to show the path the zombie is taking and the radius of the zombie's vision.
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, visionRadius);
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(transform.position, chaseRadius);
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, attackRadius);
            }
            
        }
    }
    
    
}
