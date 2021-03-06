﻿using UnityEngine;
using System.Collections;
using System;

public enum PlayerNumber { player1, player2, player3, player4};

public class Player : MonoBehaviour {

    public PlayerNumber playerNumber;
    public int playerScore;    
    public Planet[] playerPlanets;
    private bool isActive = true;

    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    void Awake()
    {
        IsActive = true;
        playerScore = 0;

        GameControl_PowerBalanceMode.gameControl.gameRun += PlayerEnergyTracker;
    }


    void OnDisable()
    {
        GameControl_PowerBalanceMode.gameControl.gameRun -= PlayerEnergyTracker;
    }
    
    /// <summary>
    /// regularly updates the player score through out game
    /// </summary>
    void PlayerEnergyTracker()
    {
        PlayerScore = 0;
        foreach (Planet planet in playerPlanets)
        {
            if (planet.IsAlive)
            {
                PlayerScore += Convert.ToInt32(planet.Energy);
            }
        }
    }


}
