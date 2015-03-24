using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum DrainType { swipeSpeed, overTime};


public class Planet : MonoBehaviour {

    public delegate void PlanetFunctions(Player drainedPlayer, float swipeSpeed);
    public PlanetFunctions hit;

    public PlayerNumber belongsToPlayer;
    public DrainType drainType;

    public int planetNumber;
    [HideInInspector]
    public float energy = 50;
    public float maxEnergy = 100;
    private float minEnergy = 0;
    [Range(-100, 0)]
    public float revivalRecovery;
    [Range(0, 10)]
    public float baseDrainSpeed = 1;
    private bool isAlive;
    public Image energyBar;
    public GameObject gainParticleSystem;
    [Range(0, 3)]
    public float gainParticleLength;
    public GameObject deathParticleSystem;
    public GameObject planetGraphics;


    public bool IsAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }

    public float MinEnergy
    {
        get { return minEnergy; }
    }

    public float Energy
    {
        get { return energy; }
        set { energy = value; }
    }

    void Start()
    {
        SetPlanetActive();

        GameControl_PowerBalanceMode.gameControl.gameRun += PlanetDeath;
        GameControl_PowerBalanceMode.gameControl.gameRun += PlanetRevival;

        if (IsAlive)
        {
            hit += EnergyGain;
            hit += EnergyDrain;
            hit += PlanetWinningIndicator;
        }
    }

	void SetPlanetActive () {
        Energy = maxEnergy / 2;
        isAlive = true;
        energyBar.fillAmount = 0.5f;
	}

    void Update()
    {
        energyBar.fillAmount = Energy / maxEnergy;
    }

    /// <summary>
    /// This increases the energy of the planet being swiped 
    /// </summary>
    /// <param name="drainingPlayer">Player recieving energy</param>
    /// <param name="drainedPlayer">Player losing energy</param>
    void EnergyGain(Player drainedPlayer, float swipeSpeed)
    {
        if (Energy < maxEnergy)
        {
            Energy += baseDrainSpeed *  swipeSpeed * Time.deltaTime;
            StartCoroutine(Particles(gainParticleLength, gainParticleSystem)); 
        }

    }

    void EnergyDrain(Player drainedPlayer, float swipeSpeed)
    {
        if (IsAlive)
        {
            drainedPlayer.playerPlanets[planetNumber - 1].Energy -= baseDrainSpeed *  swipeSpeed * Time.deltaTime;
        }
    }

    void PlanetWinningIndicator(Player drainedPlayer, float swipeSpeed)
    {
        if (planetGraphics.active)
        {
            if (Energy > drainedPlayer.playerPlanets[planetNumber - 1].Energy)
            {
                planetGraphics.renderer.material.color = new Color(180, 255, 180);
            }
            else
            {
                planetGraphics.renderer.material.color = new Color(255, 180, 180);
            }
        }
    }

    void PlanetDeath()
    {
        if (Energy < MinEnergy && IsAlive)
        {
            IsAlive = false;
            Energy = revivalRecovery;
            StartCoroutine(Particles(2, deathParticleSystem));
            planetGraphics.SetActive(false);
            if (!IsAlive)
            {
                hit -= EnergyDrain;
                hit -= PlanetWinningIndicator;
            }
        }
    }

    void PlanetRevival()
    {
        if (Energy > MinEnergy && !IsAlive)
        {
            IsAlive = true;
            Energy = 0;
            planetGraphics.SetActive(true);

            if (IsAlive)
            {
                hit += EnergyDrain;
                hit += PlanetWinningIndicator;
            }
        }
    }

    IEnumerator Particles(float particleActiveTime, GameObject particles)
    {
        if (!particles.active)
        {
            particles.SetActive(true);
            yield return new WaitForSeconds(particleActiveTime);
            particles.SetActive(false);
        }
    }
}
