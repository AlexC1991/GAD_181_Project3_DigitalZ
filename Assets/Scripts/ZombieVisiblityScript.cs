using System.Collections.Generic;
using UnityEngine;

namespace AlexzanderCowell
{
    public class ZombieVisiblityScript : MonoBehaviour
    {
        private GameObject[] _zombieParent;
        private bool _zombieVisible;
        private GameObject[] _realZombieName;
        public List<GameObject> activeZombies = new List<GameObject>();
        private HashSet<string> zombieNamesAdded = new HashSet<string>();
        private string zombieCurrentName;
        private GameObject noChildZombie;
        private bool removeAZombie;
        
        private void FixedUpdate()
        {
            if (noChildZombie != null)
            {
                Debug.Log(noChildZombie.name + "How Many Children? " + noChildZombie.transform.childCount);
            }
            
            if (ZombieSpawner.spawnedAZombie)
            {
                _zombieParent = GameObject.FindGameObjectsWithTag("ZombieParent");
                ZombieSpawner.spawnedAZombie = false;
            }

            if (_zombieParent != null)
            {
                foreach (var zombie in _zombieParent)
                {
                    zombieCurrentName = zombie.name;
                    
                    if (zombie.GetComponent<Renderer>() != null && zombie.GetComponent<Renderer>().isVisible && !zombieNamesAdded.Contains(zombieCurrentName))
                    {
                        // Add the visible zombie to the list of active zombies
                        activeZombies.Add(zombie);
                       // Adds the zombie name to the hashset.
                        zombieNamesAdded.Add(zombieCurrentName);
                    }
                }
            }

            if (_zombieParent != null)
            {
                foreach (var zomdogs in _zombieParent)
                {
                    if (!activeZombies.Contains(zomdogs))
                    {
                        zomdogs.transform.GetChild(0).gameObject.SetActive(false);
                    }
                    else if (activeZombies.Contains(zomdogs))
                    {
                        zomdogs.transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
                
                List<GameObject> zombiesToRemove = new List<GameObject>();

                foreach (var zombods in activeZombies)
                {
                    if (zombods == null)
                    {
                        zombiesToRemove.Add(zombods);
                    }
                    else if (zombods.transform.childCount < 1)
                    {
                        zombiesToRemove.Add(zombods);
                        zombieNamesAdded.Remove(zombods.name);
                    }
                }
                
                foreach (var zombieToRemove in zombiesToRemove)
                {
                    activeZombies.Remove(zombieToRemove);
                }
               
                RemoveZombiesFromActiveDuty();
            }
                
        }
        private void RemoveZombiesFromActiveDuty()
        {
            if (activeZombies.Count > 50)
            {
                activeZombies.Clear();
                zombieNamesAdded.Clear();
            }
        }
    }
}
    
            
        
    


