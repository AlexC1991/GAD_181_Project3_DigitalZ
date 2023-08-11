using System;
using UnityEngine;

public class GameModeSelection : MonoBehaviour
{
    public static bool _moreThanOnePlayer;
    public static bool _moreThanOnePlayerCheck2; 
    [SerializeField] private GameObject playerChoice;

    private void Start()
    {
        playerChoice.SetActive(true);
    }
    
    public void OnlyOnePlayer()
    {
        _moreThanOnePlayer = false;
        _moreThanOnePlayerCheck2 = true;
        playerChoice.SetActive(false);
    }

    public void TwoPlayersPlaying()
    {
        _moreThanOnePlayer = true;
        _moreThanOnePlayerCheck2 = false; 
        playerChoice.SetActive(false);
    }
}
