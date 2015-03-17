using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public enum State { Start, Running, Pause, End};
 
public class GameControl_PowerBalanceMode : MonoBehaviour {

    public static GameControl_PowerBalanceMode gameControl;
    public State state;
    public Player[] player = new Player[2];
    public Timer1 timer;
    public string winnerMessage;
    public float winningScore;
    public GameObject playAgainButton;
    public GameObject QuitButton;
    private Image powerBar;
    public float totalScore;
    public GameObject powerObject;
    public GameObject powerBarObject;
    Text winnerText;
    public GameObject winnerTextGameObject;

	// Use this for initialization
	void Start () 
    {
        gameControl = this;
        state = State.Start;
        Time.timeScale = 1;
        powerBar = powerObject.GetComponent<Image>();
        winnerText = winnerTextGameObject.GetComponent<Text>();


	}
	
	// Update is called once per frame
    void Update()
    {
        DecideWinner();
        ButtonState();
        PowerBar();
        if (state == State.End)
        {
            winnerTextGameObject.SetActive(true);
        }
        else
        {
            winnerTextGameObject.SetActive(false);
        }
    }
    void ButtonState()
    {
        if (state == State.End)
        {
            playAgainButton.SetActive(true);
            QuitButton.SetActive(true);
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

    void PowerBar()
    {
        if (state == State.Running)
        {
            powerBarObject.SetActive(true);
        }
        else
        {
            powerBarObject.SetActive(false);
        }

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

    void DecideWinner()
    {
        if (state == State.End)
        {
            if (player[0].PlayerEnergyTracker() > player[1].PlayerEnergyTracker())
            {
                //state = State.End;
                Time.timeScale = 0;
                winningScore = player[0].PlayerScore;
                winnerMessage = "Blue wins with " + Convert.ToString(winningScore) + " points";
                winnerText.text = winnerMessage;
            }
            else
            {
               // state = State.End;
                Time.timeScale = 0;
                winningScore = player[1].PlayerScore;
                winnerMessage = "Red wins with " + Convert.ToString(winningScore) + " points";
                winnerText.text = winnerMessage;
            }
        }

    }
}
