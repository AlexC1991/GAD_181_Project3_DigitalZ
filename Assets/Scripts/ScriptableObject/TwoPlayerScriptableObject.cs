using UnityEngine;

namespace AlexzanderCowell
{
    [CreateAssetMenu(fileName = "TwoPlayerModeData", menuName = "2PlayerSO/2PlayerData")]
    public class TwoPlayerScriptableObject : ScriptableObject
    {
        public static bool isTwoPlayerMode;
        public static bool additionalCheck = false;
    }
}
