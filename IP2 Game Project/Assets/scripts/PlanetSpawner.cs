using UnityEngine;
using System.Collections;

public class PlanetSpawner : MonoBehaviour {

    Object[] newPlanetObject;
    public bool isActive = true;

    /// <summary>
    /// Replaces default planets with a new set of planets(ones that are decided by the player)
    /// </summary>
    /// <param name="NewPlanets">Planets to be instantiated</param>
    /// <param name="currentPlanets">default planets to be replaced</param>
    /// <param name="player">player's planets to be assigned</param>
    public void SpawnPlanets(Planet[] NewPlanets, Planet[] currentPlanets, Player player)
    {
        if (isActive)
        {
            for (int i = 0; i < currentPlanets.Length; i++)
            {
                player.playerPlanets[i].belongsToPlayer = currentPlanets[i].belongsToPlayer;
                player.playerPlanets[i].gameController = currentPlanets[i].gameController;
                player.playerPlanets[i].energyBar = currentPlanets[i].energyBar;
                player.playerPlanets[i].planetNumber = currentPlanets[i].planetNumber;
                player.playerPlanets[i].energyBar = currentPlanets[i].energyBar;
                Destroy(currentPlanets[i].gameObject);
                player.playerPlanets[i].gameObject.SetActive(true);
                
            }
        }
    }
	
}
