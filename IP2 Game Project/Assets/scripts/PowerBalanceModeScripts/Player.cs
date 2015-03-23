using UnityEngine;
using System.Collections;
using System;

public enum PlayerNumber { player1, player2, player3, player4};

public class Player : MonoBehaviour {

    public PlayerNumber playerNumber;
    public float playerScore;    
    public Planet[] playerPlanets;
    private bool isActive = true;

    public float PlayerScore
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


}
