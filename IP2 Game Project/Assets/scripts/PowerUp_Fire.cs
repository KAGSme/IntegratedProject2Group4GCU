using UnityEngine;
using System.Collections;

public class PowerUp_Fire : MonoBehaviour {

    // feature cut from project for design reasons, feature will not currently work with in any game mode as of now 

    public float fireTime = 3f;
    public float baseDraingIncrease = 1f;
    public GameObject fireParticles;

    public void Fire(Player thePlayer, bool used)
    {
        float timer = Time.time;
        fireParticles.SetActive(true);

        foreach (Planet planet in thePlayer.playerPlanets)
        {
            planet.baseDrainSpeed += baseDraingIncrease;
        }
        
        if (Time.time - timer >= fireTime)
        {
            foreach (Planet planet in thePlayer.playerPlanets)
            {
                planet.baseDrainSpeed -= baseDraingIncrease;
            }
            fireParticles.SetActive(false);
        }
    }
}
