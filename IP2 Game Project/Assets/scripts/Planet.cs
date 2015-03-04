using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Planet : MonoBehaviour {

    public PlayerNumber belongsToPlayer;
    public int planetNumber;
    private float energy;
    public float maxEnergy = 100;
    private float minEnergy = 0;
    public float drainSpeed;
    private bool isAlive;
    private bool isActive;
    public GameControl_PowerBalanceMode gameController;
    public Image energyBar;

    public bool IsAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    public float MinEnergy
    {
        get { return minEnergy; }
        set { minEnergy = value; }
    }

    public float Energy
    {
        get { return energy; }
        set { energy = value; }
    }

	void Start () {
        Energy = maxEnergy / 2;
        isAlive = true;
        energyBar = GetComponentInChildren<Image>();
        energyBar.fillAmount = 0.5f;

	}

    void Update()
    {
        PlanetDeath();
    }
    /// <summary>
    /// This increases the energy of the planet being swiped and 
    /// decreases the energy of the mirrored planet
    /// </summary>
    /// <param name="drainingPlayer">Player recieving energy</param>
    /// <param name="drainedPlayer">Player losing energy</param>
    public void EnergyExchange(Player drainingPlayer, Player drainedPlayer)
    {
        if (Energy < maxEnergy)
        {
            Energy += drainSpeed * Time.deltaTime;
            drainingPlayer.PlayerScore += drainSpeed * Time.deltaTime;
            energyBar.fillAmount = Energy / maxEnergy;

            drainedPlayer.playerPlanets[planetNumber - 1].Energy -= drainSpeed * Time.deltaTime;
            drainedPlayer.playerPlanets[planetNumber - 1].energyBar.fillAmount = drainedPlayer.playerPlanets[planetNumber - 1].Energy / drainedPlayer.playerPlanets[planetNumber - 1].maxEnergy;
            drainedPlayer.PlayerScore -= drainSpeed * Time.deltaTime;
        }
    }

    void PlanetDeath()
    {
        if (Energy <= MinEnergy)
        {
            isAlive = false;
        }
    }
}
