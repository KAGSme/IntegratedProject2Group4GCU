using UnityEngine;
using System.Collections;

public class PowerBalance : MonoBehaviour {

    int activePlanets;
    public int activePlanetLimit;
    public Player[] players = new Player[2];
    public GameControl_PowerBalanceMode gameController;
    public float swipeSpeed = 3f;
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
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    Debug.Log("touchDetected");
                    Planet planet = null;

                    switch (touch.phase)
                    {
                        case (TouchPhase.Moved):
                            if (Physics.Raycast(ray, out hit))
                            {
                                if (hit.collider.gameObject.tag == "PlayerPlanet" && touch.deltaPosition.magnitude >= swipeSpeed)
                                {
                                    planet = hit.collider.gameObject.GetComponent<Planet>();
                                    if (planet.belongsToPlayer == PlayerNumber.player1)
                                    {
                                        planet.EnergyExchange(players[0], players[1]);
                                        players[0].playerScore++;

                                    }
                                    else if (planet.belongsToPlayer == PlayerNumber.player2)
                                    {
                                        planet.EnergyExchange(players[1], players[0]);
                                        players[1].playerScore++;
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
       if (Input.touchCount > 0)
       {
            for (int i = 0; i < Input.touchCount; i++)
            {
                GUI.Label(new Rect(0, 10 * i,200,200), " " + Input.GetTouch(i).deltaPosition.magnitude);
            }
        }
    }

}
