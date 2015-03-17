using UnityEngine;
using System.Collections;

public class PowerUp_Freeze : MonoBehaviour {

    public Player opposingPlayer;
    public PowerUp_Base powerUpBase;
    public float freezeTime = 3f;

	// Use this for initialization
	void Awake () {
        if (powerUpBase.planet.belongsToPlayer == PlayerNumber.player1)
        {
            opposingPlayer = GameObject.Find("Player 2").GetComponent<Player>();
        }
        else if (powerUpBase.planet.belongsToPlayer == PlayerNumber.player2)
        {
            opposingPlayer = GameObject.Find("Player 1").GetComponent<Player>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (powerUpBase.IsActive == true)
        {
            Freeze(freezeTime);
        }
	}

    void Freeze(float waitTime)
    {
        if (powerUpBase.IsActive == true)
        {
            float timer = Time.time;
            opposingPlayer.IsActive = false;
            if (Time.time - timer == waitTime)
            {
                opposingPlayer.IsActive = true;
            }
        }
    }
}
