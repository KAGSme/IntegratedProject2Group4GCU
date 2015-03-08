using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public enum State { Start, Running, Pause, End};
 
public class GameControl_PowerBalanceMode : MonoBehaviour {


    public State state;
    public Player[] player = new Player[2];
    public Timer1 timer;
    private string winnerMessage;
    public float winningScore;
    public GameObject playAgainButton;
    public GameObject QuitButton;
    private Image powerBar;
    public float totalScore;
    public GameObject powerObject;

	// Use this for initialization
	void Start () {
        state = State.Start;
        Time.timeScale = 1;
        powerBar = powerObject.GetComponent<Image>();

	}
	
	// Update is called once per frame
	void Update () {
        DecideWinner();
        ButtonState();
        totalScore = player[0].playerScore + player[1].playerScore;
        if (player[0].playerScore == player[1].playerScore)
        {
            powerBar.fillAmount = 0.5f;
        }
        else
        {
            powerBar.fillAmount = player[0].playerScore / totalScore;

        }

	}


    void OnGUI()
    {

        if (state == State.End)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 800, 400), winnerMessage + Convert.ToInt32(winningScore) + " points");

        }
        
    }
    void ButtonState()
    {
        if (state == State.End)
        {
            playAgainButton.active = true;
            QuitButton.active = true;
        }
    }

    public void PlayAgain()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
        Application.Quit();
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
