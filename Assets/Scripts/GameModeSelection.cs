using System;
using UnityEngine;

public class GameModeSelection : MonoBehaviour
{
    public static bool _moreThanOnePlayer;
    [SerializeField] private GameObject playerChoice;

    private void Start()
    {
        playerChoice.SetActive(true);
    }
    
    public void OnlyOnePlayer()
    {
        _moreThanOnePlayer = false;
        playerChoice.SetActive(false);
    }

    public void TwoPlayersPlaying()
    {
        _moreThanOnePlayer = true;
        playerChoice.SetActive(false);
    }
}
