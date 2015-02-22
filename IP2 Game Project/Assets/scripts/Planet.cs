using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

    public int belongsToPlayer;
    public int planetNumber;
    public float energy;
    public float maxEnergy;
    public float minEnergy;
    public float drainSpeed;
    public bool isAlive;
    public bool isActive;

	void Start () {
        energy = maxEnergy / 2;
        isAlive = true;
	}

    void Update()
    {
        PlanetDeath();
    }
	
	void OnGUI () {
        GUI.Label(new Rect(0 + 200 * belongsToPlayer - 1, 0 + 50 * planetNumber, 200, 200), "Player " 
            + belongsToPlayer + ", Planet " + planetNumber + ", Energy: " + energy);
	}

    public void EnergyExchange(Player drainingPlayer, Player drainedPlayer)
    {
        energy += drainSpeed * Time.deltaTime;
        drainingPlayer.playerScore += drainSpeed * Time.deltaTime;

        drainedPlayer.playerPlanets[planetNumber].energy -= drainSpeed * Time.deltaTime;
        drainedPlayer.playerScore += drainSpeed * Time.deltaTime;
    }

    void PlanetDeath()
    {
        if (energy <= minEnergy)
        {
            isAlive = false;
        }
    }
}
