using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

    private float playerScore;
    public GameObject[] player1Planets = new GameObject[9];
    public GameObject[] player2Planets = new GameObject[9];


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SwipePower();
	}

    //when you get the input, it creates a ray at mouse position, then it's going to check if the object hit was one of player 1 particles or one of player 2 particles.
    //Then its going to get the PowerBalance script of the hit object to increase its energy level
    //And then its going to get the PowerBalance script of the mirrored object and decrease its value;
    //The way this works is: In the Unity Editor, all particles are named from 1-9, when you hit a particle (e.g. 3) and if it belongs to the player1Particles[],
    //its going to look in the player2Particles[] for the same name. 
    void SwipePower()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "player1particles") 
                {
                    PowerBalance power1 = hit.transform.GetComponent<PowerBalance>();
                    power1.IncreaseValue();
                    int i = Convert.ToInt32(hit.transform.name); 
                    PowerBalance power2 = player2Planets[i-1].GetComponent<PowerBalance>(); //i-1 because array starts at 0
                    power2.DecraseValue();
                    
                }
                else if (hit.collider.gameObject.tag == "player2particles")
                {
                    PowerBalance power1 = hit.transform.GetComponent<PowerBalance>();
                    power1.IncreaseValue();
                    int i = Convert.ToInt32(hit.transform.name);
                    PowerBalance power2 = player1Planets[i-1].GetComponent<PowerBalance>();
                    power2.DecraseValue();
                }

            }
        }
    }

    float TotalScore()
    {
        return playerScore;
    }
}
