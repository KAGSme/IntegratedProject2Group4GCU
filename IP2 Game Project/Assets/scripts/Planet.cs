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
    public Texture2D backgroundEnergyBar;
    public Texture2D energyBar;
    public float energyBarWidth;
    public GameControl_PowerBalanceMode gameController;
    public float rotAngle = -90;
    private Vector2 pivotPoint;
    public float x;
    public float y;

	void Start () {
        energy = maxEnergy / 2;
        isAlive = true;
        energyBarWidth = energy;
        //backgroundEnergyBar = energyBar;
	}

    void Update()
    {
        PlanetDeath();
    }
	
	void OnGUI () {
        //GUI.Label(new Rect(0 + 200 * belongsToPlayer - 1, 0 + 50 * planetNumber, 200, 200), "Player " 
            //+ belongsToPlayer + ", Planet " + planetNumber + ", Energy: " + energy);
        if (gameController.state == State.Running)
        {

            pivotPoint = new Vector2(x, y);
            GUIUtility.RotateAroundPivot(rotAngle, pivotPoint);
            GUI.DrawTexture(new Rect(x, y, 50, 20), backgroundEnergyBar);
            GUI.DrawTexture(new Rect(x, y, energyBarWidth, 20), energyBar);
        }

	}

    public void EnergyExchange(Player drainingPlayer, Player drainedPlayer)
    {
        energy += drainSpeed * Time.deltaTime;
        drainingPlayer.playerScore += drainSpeed * Time.deltaTime;
        energyBarWidth += drainSpeed * Time.deltaTime;

        drainedPlayer.playerPlanets[planetNumber - 1].energy -= drainSpeed * Time.deltaTime;
        drainedPlayer.playerPlanets[planetNumber - 1].energyBarWidth -= drainSpeed * Time.deltaTime;
        drainedPlayer.playerScore -= drainSpeed * Time.deltaTime;
    }

    void PlanetDeath()
    {
        if (energy <= minEnergy)
        {
            isAlive = false;
        }
    }
}
