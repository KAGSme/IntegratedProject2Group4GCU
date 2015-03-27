using UnityEngine;
using System.Collections;

public class PowerUp_Base : MonoBehaviour {

    [Range(0,500)]
    public int maxScoreLimit = 400;
    [Range(0,500)]
    public int minScoreLimit = 50;
    Player player;
    public bool isActive;

    void Start()
    {
        isActive = false;
    }

    void OnEnable()
    {
        GameControl_PowerBalanceMode.gameControl.gameRun += EnergyCheck;
    }

    void EnergyCheck()
    {

    }
}
