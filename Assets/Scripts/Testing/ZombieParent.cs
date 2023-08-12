using UnityEngine;

namespace AlexzanderCowell
{
    
    public class ZombieParent : MonoBehaviour
    {
        public bool IsVisibleInCameraFrustum { get; private set; }

        private void OnBecameVisible()
        {
            IsVisibleInCameraFrustum = true;
        }

        private void OnBecameInvisible()
        {
            IsVisibleInCameraFrustum = false;
        }
    }
}
