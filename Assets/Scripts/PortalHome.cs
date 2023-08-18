using UnityEngine;
using UnityEngine.SceneManagement;

namespace AlexzanderCowell
{
    public class PortalHome : MonoBehaviour
    {
        private AudioSource loadSound;

        private void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("Player"))
            {
                loadSound = GetComponent<AudioSource>();
                SceneManager.LoadScene("PlayerRoom");
            }
        }
    }
}
