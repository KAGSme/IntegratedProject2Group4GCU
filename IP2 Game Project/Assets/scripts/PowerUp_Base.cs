using UnityEngine;
using System.Collections;

public class PowerUp_Base : MonoBehaviour {

    public delegate void PowerUpFunc();
    public PowerUpFunc PowerUp;

    [Range(0,500)]
    public int maxScoreLimit = 400;
    [Range(0,500)]
    public int minScoreLimit = 50;
    public Player player;
    bool isActive;
    PowerUp_Freeze freeze;


    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    void Start()
    {
        isActive = false;
        freeze = GetComponent<PowerUp_Freeze>();
    }

    void OnEnable()
    {
        GameControl_PowerBalanceMode.gameControl.gameRun += EnergyCheck;
    }

    void EnergyCheck()
    {
            if (!isActive)
        {
            if (player.PlayerScore >= maxScoreLimit || player.PlayerScore <= minScoreLimit)
            {
                IsActive = true;
                if (PowerUp != null)
                {
                    PowerUp();
                }
            }
        }
    }

    public void SetFreeze()
    {
        PowerUp += freeze.Freeze;
    }
}
