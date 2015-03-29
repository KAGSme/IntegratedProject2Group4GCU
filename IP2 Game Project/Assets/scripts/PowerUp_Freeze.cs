using UnityEngine;
using System.Collections;

public class PowerUp_Freeze : MonoBehaviour {

    public Player opposingPlayer;
    public float freezeTime = 3f;
    public GameObject FreezeParticles;

    public void Freeze(Player thePlayer, bool used)
    {
        float timer = Time.time;
        opposingPlayer.IsActive = false;
        if (Time.time - timer >= freezeTime)
        {
            opposingPlayer.IsActive = true;
            used = true;
        }
    }
}
