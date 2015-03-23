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
                    case (TouchPhase.Moved):
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.gameObject.tag == "PlayerPlanet" && touch.deltaPosition.magnitude >= swipeSpeed)
                            {
                                Planet planet = hit.collider.gameObject.GetComponent<Planet>();
                                Player drainedPlayer = players[0];
                                drainedPlayer = planet.belongsToPlayer == PlayerNumber.player1 ? drainedPlayer = players[1] :  drainedPlayer = players[0];
                                if (planet.hit != null)
                                {
                                    planet.hit(drainedPlayer, touch.deltaPosition.magnitude);
                                }
                            }
                        }
                        break;
                }
            }
        }  
    }
}
