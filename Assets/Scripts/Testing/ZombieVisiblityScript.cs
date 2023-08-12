using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace AlexzanderCowell
{
    public class ZombieVisiblityScript : MonoBehaviour
    {
        /*private GameObject _playerCam;*/
        private Camera _mainCamera;
        private Collider _enemyCollider;
        private Plane[] _cameraPlanes;
        private bool isVisible;
        /*private SkinnedMeshRenderer[] _zombieMeshRenderer;*/
        private Bounds boundry;
       /*[SerializeField] private GameObject[] invisibleZombies;*/
       private GameObject[] zombieParent;
       private GameObject zombieName;
     

        private void Awake()
        {
            /*_mainCamera = Camera.main;
            _enemyCollider = gameObject.CompareTag("ZombieParent") ? GetComponent<CapsuleCollider>() : GetComponent<BoxCollider>();
            zombieParent = GameObject.FindGameObjectsWithTag("ZombieParent");*/
            /*invisibleZombies = GameObject.FindGameObjectsWithTag("Zombie");*/
            
            zombieParent = GameObject.FindGameObjectsWithTag("ZombieParent");
        }

        private void Start()
        {
            foreach (GameObject zombieParents in zombieParent)
            {
                // Deactivate the child zombie GameObjects initially
                zombieParents.transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            
                /*boundry = _enemyCollider.bounds;
                _cameraPlanes = GeometryUtility.CalculateFrustumPlanes(_mainCamera);
                isVisible = GeometryUtility.TestPlanesAABB(_cameraPlanes, boundry);

                if (isVisible)
                {
                    Debug.Log("Found This Game Object"  + _enemyCollider.name);
                }
                
                /#1#/ Toggle the child zombie's active status based on visibility of the parent
                zombieParents.transform.GetChild(0).gameObject.SetActive(isVisible);#1#*/
                
                foreach (GameObject zombieParents in zombieParent)
                {
                    if (zombieParents.GetComponent<ZombieParent>().IsVisibleInCameraFrustum)
                    {
                        Debug.Log("Visible Zombie Parent: " + zombieParents.gameObject.name);
                        // You can do more with the visible zombie parent here
                    }
                }
            

        }
    }
}

