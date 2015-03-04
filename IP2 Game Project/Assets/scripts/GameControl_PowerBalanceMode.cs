using UnityEngine;
using System.Collections;
using System;

public enum State { Start, Running, Pause, End};
 
public class GameControl_PowerBalanceMode : MonoBehaviour {


    public State state;
    public Texture2D[] ThreeTwoOne = new Texture2D[3];
    public Texture2D[] ThreeTwoOne_2 = new Texture2D[3];
    public Texture2D displayedTexture = null;
    public Texture2D displayedTexture_2;
    public Player[] player = new Player[2];
    public Timer1 timer;
    private string winnerMessage;
    public float winningScore;


	// Use this for initialization
	void Start () {
        state = State.Start;
        StartCoroutine("CountDown");
        StartCoroutine("CountDown_2");
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        DecideWinner();

	}


    void OnGUI()
    {

         
        if (displayedTexture != null)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 100, Screen.height / 2, 100, 100), displayedTexture);
        }
        if (displayedTexture_2 != null)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 +30 , Screen.height / 2, 100, 100), displayedTexture_2);
        }
        if (state == State.End)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 800, 400), winnerMessage + Convert.ToInt32(winningScore) + " points");
            if(GUI.Button(new Rect (Screen.width/2, Screen.height/2 +50, 100,50), "Play Again"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        
    }

    IEnumerator CountDown()
    {
        for (int i = 0; i < ThreeTwoOne.Length; i++)
        {
            displayedTexture = ThreeTwoOne[i];
            yield return new WaitForSeconds(1);
            
        }
        displayedTexture = null;
        state = State.Running;
    }
    IEnumerator CountDown_2()
    {
        for (int i = 0; i < ThreeTwoOne_2.Length; i++)
        {
            displayedTexture_2 = ThreeTwoOne_2[i];
            yield return new WaitForSeconds(1);

        }
        displayedTexture_2 = null;
    }

    void DecideWinner()
    {
        if (timer.timer == 0)
        {
            if (player[0].PlayerEnergyTracker() > player[1].PlayerEnergyTracker())
            {
                state = State.End;
                Time.timeScale = 0;
                winningScore = player[0].PlayerScore;
                winnerMessage = "Player 1 wins with ";
            }
            else
            {
                state = State.End;
                Time.timeScale = 0;
                winningScore = player[1].PlayerScore;
                winnerMessage = "Player 2 wins with ";
            }
        }

    }
}
