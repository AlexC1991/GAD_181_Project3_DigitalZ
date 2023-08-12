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
        private GameObject zombie;
        private void FixedUpdate()
        {
            if (ZombieSpawner.spawnedAZombie)
            {
                _zombieParent = GameObject.FindGameObjectsWithTag("ZombieParent");
                ZombieSpawner.spawnedAZombie = false;
            }

            if (_zombieParent != null)
            {
                foreach (var zombie in _zombieParent)
                {
                    if (zombie.GetComponent<Renderer>() != null && zombie.GetComponent<Renderer>().isVisible)
                    {
                        // Add the visible zombie to the list of active zombies
                        activeZombies.Add(zombie);
                    }
                }
            }

            if (_zombieParent != null)
            {
                foreach (var zombie in _zombieParent)
                {
                    if (!activeZombies.Contains(zombie) && zombie.transform.childCount > 0)
                    {
                        zombie.transform.GetChild(0).gameObject.SetActive(false);
                    }
                    else if (activeZombies.Contains(zombie) && zombie.transform.childCount > 0)
                    {
                        zombie.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    if (activeZombies.Count > 35) 
                    {
                        activeZombies.Clear();
                    }
                }
            }
                
        }
    }
}
    
            
        
    


