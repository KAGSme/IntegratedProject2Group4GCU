using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

    public int playerNumber;
    public float playerScore;    
    public Planet[] playerPlanets;


    void Start()
    {
        playerScore = 0f;
    }

    void Update()
    {
    }

    void PlayerScoreTracker()
    {
        foreach (Planet planet in playerPlanets)
        {
            playerScore += planet.energy;
        }
    }
}
