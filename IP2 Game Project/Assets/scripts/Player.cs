using UnityEngine;
using System.Collections;
using System;

public enum PlayerNumber { player1, player2, player3, player4};

public class Player : MonoBehaviour {

    public PlayerNumber playerNumber;
    public float playerScore;    
    public Planet[] playerPlanets;
    public Planet[] playerPlanetDeck;
    public PlanetSpawner pSpawn;
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

    void Start()
    {
        IsActive = true;
        playerScore = 0f;
        if (pSpawn != null)
        {
            pSpawn.SpawnPlanets(playerPlanetDeck, playerPlanets, this);
        }
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

    //void OnGUI()
    //{
    //    if (playerNumber == PlayerNumber.player1)
    //    {
    //        GUI.Label(new Rect(Screen.width / 2, 10, 200, 200), "Player 1 score" + playerScore);
    //        GUI.Label(new Rect(Screen.width / 2, 30, 200, 200), "Planet 1 score" + playerPlanets[0].Energy);
    //    }
    //}
}
