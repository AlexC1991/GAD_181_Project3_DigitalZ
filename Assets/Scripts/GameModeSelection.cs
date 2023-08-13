using AlexzanderCowell;
using UnityEngine;

public class GameModeSelection : MonoBehaviour
{
    [SerializeField] private GameObject playerChoice;

    private void Start()
    {
        playerChoice.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void OnePlayer()
    {
        TwoPlayerScriptableObject.isTwoPlayerMode = false;
        TwoPlayerScriptableObject.additionalCheck = true;
    }
    
    public void TwoPlayer()
    {
        TwoPlayerScriptableObject.isTwoPlayerMode = true;
        TwoPlayerScriptableObject.additionalCheck = false;
    }


    private void Update()
    {
        if (TwoPlayerScriptableObject.isTwoPlayerMode && !TwoPlayerScriptableObject.additionalCheck)
        {
            TwoPlayersPlaying();
        }
        else if (!TwoPlayerScriptableObject.isTwoPlayerMode && TwoPlayerScriptableObject.additionalCheck)
        {
            OnlyOnePlayer();
        }
    }

    private void OnlyOnePlayer()
    {
        Time.timeScale = 1;
        playerChoice.SetActive(false);
    }

    private void TwoPlayersPlaying()
    {
        Time.timeScale = 1;
        playerChoice.SetActive(false);
    }
}
