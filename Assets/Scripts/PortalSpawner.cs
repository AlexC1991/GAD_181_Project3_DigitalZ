using UnityEngine;

namespace AlexzanderCowell
{
    public class PortalSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] portalSpawns;
        [SerializeField] private GameObject portal;
        private GameObject _randomPortal;


        private void Start()
        {
            _randomPortal = portalSpawns[UnityEngine.Random.Range(0, portalSpawns.Length)];
            
            Instantiate(portal, _randomPortal.transform.position, Quaternion.identity);
        }
    }
}
