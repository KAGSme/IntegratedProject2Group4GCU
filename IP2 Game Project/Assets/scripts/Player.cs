using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

    private float playerScore;
    public int playerNumber;
    private string status = "";
    public GameObject[] player1Particles = new GameObject[9];
    public GameObject[] player2Particles = new GameObject[9];

//    public float minSwipeDistance;
    private Vector2 touchStartPosition;
    public int t;
    float guiEnergy;

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
        if (Input.touchCount >0)
        {
            Touch touch = Input.touches[0];
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            Debug.Log("Hurray!");
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    status = "Begin";
                    touchStartPosition = touch.position;
                    break;
                case TouchPhase.Moved:
                    status = "moving";
                    
                    float swipeDistance =( touch.position - touchStartPosition).magnitude;
                    Debug.Log(swipeDistance);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject.tag == "player1particles" && playerNumber == 1 /*&& swipeDistance > minSwipeDistance*/)
                        {

                            t++;
                            status = "hit";
                            PowerBalance power1 = hit.transform.GetComponent<PowerBalance>();
                            guiEnergy = power1.particleValue;
                            power1.IncreaseValue();
                            int i = Convert.ToInt32(hit.transform.name);
                            PowerBalance power2 = player2Particles[i - 1].GetComponent<PowerBalance>(); //i-1 because array starts at 0
                            power2.DecraseValue();


                        }
                        else if (hit.collider.gameObject.tag == "player2particles" && playerNumber == 2 /*&& swipeDistance > minSwipeDistance*/)
                        {
                            status = "hit";
                            PowerBalance power1 = hit.transform.GetComponent<PowerBalance>();
                            power1.IncreaseValue();
                            int i = Convert.ToInt32(hit.transform.name);
                            PowerBalance power2 = player1Particles[i - 1].GetComponent<PowerBalance>();
                            power2.DecraseValue();
                            
                        }
                        touchStartPosition = touch.position;
            }
                    break; 

            }
        }
    }

    float TotalScore()
    {
        return playerScore;
    }

    void OnGUI()
    {
        //foreach(Touch touch in Input.touches){
            //int num = touch.fingerId;
           // GUI.Label(new Rect(0 + 200 * num, 10, 200, 200), touch.fingerId + "Player 1 Planet Energy: "  + guiEnergy);
        //}

    }

}
