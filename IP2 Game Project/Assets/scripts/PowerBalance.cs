using UnityEngine;
using System.Collections;

public class PowerBalance : MonoBehaviour {

    public float particleValue = 50; //The energy level they start with
    public float speed = 1; //How much they increase/decrease per touch
    public int planetNumber;
    public int playerNumber;
    
    
	
    //Use this method when you want to increase the energy level
    public void IncreaseValue()
    {
        particleValue += speed * Time.deltaTime;
    }

    //And this one to decrease it. 
    public void DecraseValue( )
    {
        particleValue -= speed * Time.deltaTime;     
    }
    
    //Going to be used by the Player script to return the total score of the player, by summing up all particle values
    float GetParticleValue()
    {
        return particleValue;
    }

    void OnGUI()
    {
                GUI.Label(new Rect(0 + 200 * playerNumber - 1, 0 + 50 * planetNumber, 200, 200), "Player " + playerNumber + ", Planet " + planetNumber + ", Energy: " + particleValue);
    }

}
