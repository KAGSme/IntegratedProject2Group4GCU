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
    public GameObject planetTouchGraphics;
    public GameObject warningSign;
    public AudioClip PlanetDiesAudio;
    public AudioClip PlanetNearDeathAudio;
    public AudioClip PlanetRevivalAudio;



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
        warningSign.SetActive(false);

        GameControl_PowerBalanceMode.gameControl.gameRun += PlanetDeath;    // subscribe to game state
        GameControl_PowerBalanceMode.gameControl.gameRun += PlanetRevival; // subscribe to game state
        GameControl_PowerBalanceMode.gameControl.gameRun += PlanetDeathIndicator; // subscribe to game state

        if (IsAlive)
        {
            hit += EnergyGain;
            hit += EnergyDrain;
        }

        planetTouchGraphics.SetActive(false);
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

        if (!IsAlive && !audio.isPlaying)
        {
            audio.clip = PlanetRevivalAudio;
            audio.Play();
        }
    }


    /// <summary>
    /// Drains energy from opposing players planet
    /// </summary>
    /// <param name="drainedPlayer"></param>
    /// <param name="swipeSpeed"></param>
 
    void EnergyDrain(Player drainedPlayer, float swipeSpeed)
    {
        if (IsAlive)
        {
            drainedPlayer.playerPlanets[planetNumber - 1].Energy -= baseDrainSpeed *  swipeSpeed * Time.deltaTime;
        }
    }

    /// <summary>
    /// Activates appropriate sound effects to tell player that the energy of planet is low
    /// </summary>
    void PlanetDeathIndicator()
    {
        if (Energy < 15 && IsAlive && !audio.isPlaying)
        {
            audio.clip = PlanetNearDeathAudio;
            audio.Play();
            warningSign.SetActive(true);
        }
        if (Energy > 15 || !IsAlive)
        {
            warningSign.SetActive(false);
        }
    }

    /// <summary>
    /// implements appropriate behaviour that occurs when planet energy reaches 0 
    /// </summary>
 
    void PlanetDeath()
    {
        if (Energy < MinEnergy && IsAlive)
        {
            IsAlive = false;
            Energy = revivalRecovery;
            if (PlanetDiesAudio != null) {
                audio.clip = PlanetDiesAudio;
                audio.Play(); 
            }
            StartCoroutine(Particles(2, deathParticleSystem));
            planetGraphics.SetActive(false);
            if (!IsAlive)
            {
                hit -= EnergyDrain;
            }
        }
    }

    /// <summary>
    /// implements appropriate behaviour that occurs when planet energy reaches above 0 to "bring it back to life"
    /// </summary>
 
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
            }
        }
    }

    public IEnumerator Particles(float particleActiveTime, GameObject particles)
    {
        if (!particles.active)
        {
            particles.SetActive(true);
            yield return new WaitForSeconds(particleActiveTime);
            particles.SetActive(false);
        }
    }

    public void OnTouch()
    {
        Debug_Android.debugAOS.Output("PlanetTouchDown");
        StartCoroutine(Particles(0.1f, planetTouchGraphics));
    }
}
