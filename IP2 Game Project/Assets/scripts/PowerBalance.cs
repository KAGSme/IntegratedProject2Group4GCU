using UnityEngine;
using System.Collections;

public class PowerBalance : MonoBehaviour {

    int activePlanets;
    public int activePlanetLimit;
    public Player[] players = new Player[2];
    public GameControl_PowerBalanceMode gameController;

    string touchesCheck;
    void Update()
    {
        PlayerSwipe();
    }

    void PlayerSwipe()
    {
        if (gameController.state == State.Running)
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch touch = Input.GetTouch(i);
                    touchesCheck = "touchDetected";
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    Debug.Log("touchDetected");

                    switch (touch.phase)
                    {

                        case (TouchPhase.Moved):
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

    void OnGUI()
    {
        GUI.Label(new Rect(1000, 0, 200, 200), touchesCheck);
    }
}
