using UnityEngine;
using UnityEngine.SceneManagement;

namespace AlexzanderCowell
{
    public class PortalHome : MonoBehaviour
    {
        private void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene("PlayerRoom");
            }
        }
    }
}
