using UnityEngine;

namespace AlexzanderCowell
{
    [CreateAssetMenu(fileName = "NewUserData", menuName = "Custom/User Data")]
    public class UserData : ScriptableObject
    {
        public string username;

        public string password;
    }
}
