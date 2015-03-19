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
    public void SpawnPlanets(GameObject[] NewPlanets, Planet[] currentPlanets, Player player)
    {
        if (isActive)
        {
            Planet[] newPlanetScript = null;
            for (int i = 0; i < currentPlanets.Length; i++)
            {
                Planet tempPlanet; 
                Instantiate((GameObject)NewPlanets[i], currentPlanets[i].gameObject.transform.position, Quaternion.identity);
                tempPlanet = NewPlanets[i].gameObject.GetComponent<Planet>();
                newPlanetScript[i] = tempPlanet;
                newPlanetScript[i].belongsToPlayer = currentPlanets[i].belongsToPlayer;
                newPlanetScript[i].gameController = currentPlanets[i].gameController;
                newPlanetScript[i].energyBar = currentPlanets[i].energyBar;
                newPlanetScript[i].planetNumber = currentPlanets[i].planetNumber;
                newPlanetScript[i].SetPlanetActive();
                Destroy(currentPlanets[i].gameObject);
                
            }
        }
    }
	
}
