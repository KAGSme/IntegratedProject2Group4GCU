using UnityEngine;
using System.Collections;

public class PowerUp_Base : MonoBehaviour {

    public delegate void PowerUpFunc(Player thePlayer, bool used);
    public PowerUpFunc PowerUp;

    [Range(0,500)]
    public int maxScoreLimit = 400;
    [Range(0,500)]
    public int minScoreLimit = 50;
    public Player player;
    bool isActive;
    bool used;
    PowerUp_Freeze freeze;
    PowerUp_Fire fire;


    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }
    public bool Used
    {
        get { return used; }
        set { used = value; }
    }

    void Start()
    {
        isActive = false;
        used = false;
        freeze = GetComponent<PowerUp_Freeze>();
        fire = GetComponent<PowerUp_Fire>();
        PowerUp = fire.Fire;
    }

    void OnStart()
    {
        GameControl_PowerBalanceMode.gameControl.gameRun += EnergyCheck;
    }

    void EnergyCheck()
    {
        if (!IsActive)
        {
            if (player.PlayerScore >= maxScoreLimit || player.PlayerScore <= minScoreLimit)
            {
                IsActive = true;
            }
        }
        else { IsActive = false; }
        if (PowerUp != null && IsActive && !used)
        {
            PowerUp(player, Used);
        }
    }

    public void SetFreeze()
    {
        PowerUp = freeze.Freeze;
    }

    public void SetFire()
    {
        PowerUp = fire.Fire;
    }
}
