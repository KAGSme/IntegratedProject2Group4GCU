using UnityEngine;
using System.Collections;

public class PowerBalance : MonoBehaviour {

    int activePlanets;
    public int activePlanetLimit;
    Player[] players = new Player[2];

    void Update()
    {
        PlayerSwipe();
    }

    void PlayerSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch[] myTouches = Input.touches;
            for (int i = 0; i < Input.touchCount; i++)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[i].position);
                Debug.Log("touchDetected");

                switch (Input.touches[i].phase)
                {
                    case TouchPhase.Moved:
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.gameObject.tag == "PlayerPlanet")
                            {
                                Planet planet = hit.collider.gameObject.GetComponent<Planet>();
                                if (planet.belongsToPlayer == 1)
                                {
                                    planet.EnergyExchange(players[0], players[1]);
                                }
                                else if (planet.belongsToPlayer == 2)
                                {
                                    planet.EnergyExchange(players[1], players[0]);
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}
