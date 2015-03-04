using UnityEngine;
using System.Collections;

public class PlanetSpawner : MonoBehaviour {

    /// <summary>
    /// Replaces default planets with a new set of planets(ones that are decided by the player)
    /// </summary>
    /// <param name="planets">Planets to be instantiated</param>
    /// <param name="currentPlanets">default planets to be replaced</param>
    /// <param name="player">default planets to be replaced</param>
    public void SpawnPlanets(Planet[] planets, Planet[] currentPlanets, Player player)
    {
        for (int i = 0; i < currentPlanets.Length; i++)
        {
            Instantiate(planets[i], currentPlanets[i].transform.position, Quaternion.identity);
            planets[i].Energy = currentPlanets[i].Energy;
            planets[i].belongsToPlayer = currentPlanets[i].belongsToPlayer;
            planets[i].gameController = currentPlanets[i].gameController;
            planets[i].energyBar = currentPlanets[i].energyBar;
            planets[i].planetNumber = currentPlanets[i].planetNumber;
            player.playerPlanets[i] = planets[i];
            Destroy(currentPlanets[i].gameObject);
        }
    }
	
}
