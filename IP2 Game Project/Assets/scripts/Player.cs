﻿using UnityEngine;
using System.Collections;
using System;

public enum PlayerNumber { player1, player2, player3, player4};

public class Player : MonoBehaviour {

    public PlayerNumber playerNumber;
    private float playerScore;    
    public Planet[] playerPlanets;

    public float PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }


    void Start()
    {
        playerScore = 0f;
    }

    void Update()
    {
    }

    public float PlayerEnergyTracker()
    {
        float totalEnergy = 0;
        foreach (Planet planet in playerPlanets)
        {
            totalEnergy += planet.Energy;
        }
        return totalEnergy;
    }

    void OnGUI()
    {
        if (playerNumber == PlayerNumber.player1)
        {
            GUI.Label(new Rect(Screen.width / 2, 10, 200, 200), "Player 1 score" + playerScore);
            GUI.Label(new Rect(Screen.width / 2, 30, 200, 200), "Planet 1 score" + playerPlanets[0].Energy);
        }
    }
}
