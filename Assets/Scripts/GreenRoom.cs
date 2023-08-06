using UnityEngine;
using UnityEngine.SceneManagement;
namespace AlexzanderCowell
{
    public class GreenRoom : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene("ZombieLand");
            }
        }
    }
}
