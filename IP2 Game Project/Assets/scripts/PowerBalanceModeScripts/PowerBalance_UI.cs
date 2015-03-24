using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PowerBalance_UI : MonoBehaviour {

    public GameObject winnerTextGameObject;
    Text winnerText;
    float winningScore;
    string winnerMessage;
    public GameObject playAgainButton;
    

	// Use this for initialization
	void Start () {
        winnerText = winnerTextGameObject.GetComponent<Text>();
        winnerTextGameObject.SetActive(false);

        GameControl_PowerBalanceMode.gameControl.gameEnd += ButtonState;
        GameControl_PowerBalanceMode.gameControl.gameEnd += DecideWinner;
    }

    void OnDisable()
    {
        GameControl_PowerBalanceMode.gameControl.gameEnd -= ButtonState;
        GameControl_PowerBalanceMode.gameControl.gameEnd -= DecideWinner;
    }

    void ButtonState()
    {
        playAgainButton.SetActive(true);
    }

    public void PlayAgain()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void DecideWinner()
    {
        winnerTextGameObject.SetActive(true);

        Time.timeScale = 0;

        winnerMessage = GameControl_PowerBalanceMode.gameControl.player[0].PlayerScore > GameControl_PowerBalanceMode.gameControl.player[1].PlayerScore ?
            "Blue wins with " + Convert.ToString(GameControl_PowerBalanceMode.gameControl.player[0].PlayerScore) + " points" : "Red wins with " + Convert.ToString(GameControl_PowerBalanceMode.gameControl.player[1].PlayerScore) + " points";

        winnerText.text = winnerMessage;
    }
	
    
}
