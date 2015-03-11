using UnityEngine;
using System.Collections;

public class PowerUp_Freeze : MonoBehaviour {

    Player player;
    public PowerUp_Base powerUpBase;
    public float freezeTime = 3f;
    public GameObject FreezeButton;

	// Use this for initialization
	void Start () {
        if (powerUpBase.planet.belongsToPlayer == PlayerNumber.player1)
        {
            player = GameControl_PowerBalanceMode.gameControl.player[0];
        }
        else if (powerUpBase.planet.belongsToPlayer == PlayerNumber.player2)
        {
            player = GameControl_PowerBalanceMode.gameControl.player[1];
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (powerUpBase.IsActive == true)
        {
            FreezeButton.SetActive(true);
        }
	}

    void Freeze(float waitTime)
    {
        if (powerUpBase.IsActive == true)
        {
            float timer = Time.time;
            player.IsActive = false;
            if (Time.time - timer == waitTime)
            {
                powerUpBase.IsActive = false;
            }
        }
    }
}
