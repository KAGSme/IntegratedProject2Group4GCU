using UnityEngine;
using System.Collections;
using System;

public class PowerBalance_Input : MonoBehaviour {

    public static PowerBalance_Input pBInput;

    public Player[] players = new Player[2];
    [Range(0, 5)]
    public float swipeSpeed = 3f;

    void Awake()
    {
        if (pBInput == null) pBInput = this; else if(pBInput != this) DestroyObject(this); 
    }

    void Start()
    {
        GameControl_PowerBalanceMode.gameControl.gameRun += PlayerSwipe;
    }

    void OnDisable()
    {
        GameControl_PowerBalanceMode.gameControl.gameRun -= PlayerSwipe;
    }

    void PlayerSwipe()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                switch (touch.phase)
                {
                    case(TouchPhase.Began):
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.gameObject.tag == "PlayerPlanet")
                            {
                                Planet planet = hit.collider.gameObject.GetComponent<Planet>();
                                planet.OnTouch();
                            }
                        }
                        break;
                    case (TouchPhase.Moved):
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.gameObject.tag == "PlayerPlanet" && touch.deltaPosition.magnitude >= swipeSpeed)
                            {
                                Planet planet = hit.collider.gameObject.GetComponent<Planet>();
                                Player drainedPlayer = players[0];
                                planet.OnTouch();
                                drainedPlayer = planet.belongsToPlayer == PlayerNumber.player1 ? drainedPlayer = players[1] :  drainedPlayer = players[0];
                                Player drainingPlayer = players[1];
                                drainingPlayer = drainedPlayer == players[1] ? drainingPlayer = players[0] : drainingPlayer = players[1];
                                if (planet.hit != null && drainingPlayer.IsActive)
                                {
                                    planet.hit(drainedPlayer, touch.deltaPosition.magnitude);
                                }
                            }
                        }
                        break;
                    case (TouchPhase.Stationary):
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.gameObject.tag == "PlayerPlanet")
                            {
                                Planet planet = hit.collider.gameObject.GetComponent<Planet>();
                                planet.OnTouch();
                            }
                        }
                        break;
                }
            }
        }  
    }
}
