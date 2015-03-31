using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PowerBalance_UI : MonoBehaviour {

    public GameObject Player1TextObject;
    public GameObject Player2TextObject;
    Text Player1Text;
    Text Player2Text;
    public GameObject playAgainButton;
    

	// Use this for initialization
	void Start () {
        Player1TextObject.SetActive(false);
        Player2TextObject.SetActive(false);

        Player1Text = Player1TextObject.GetComponent<Text>();
        Player2Text = Player2TextObject.GetComponent<Text>();

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
        Player1TextObject.SetActive(true);
        Player2TextObject.SetActive(true);

        Time.timeScale = 0;

        if (GameControl_PowerBalanceMode.gameControl.player[0].PlayerScore > GameControl_PowerBalanceMode.gameControl.player[1].PlayerScore)
        {
            Player1Text.text = "You Win!";
            Player2Text.text = "You Lose!";
        }
        else if (GameControl_PowerBalanceMode.gameControl.player[1].PlayerScore > GameControl_PowerBalanceMode.gameControl.player[0].PlayerScore)
        {
            Player2Text.text = "You Win!";
            Player1Text.text = "You Lose!";
        }
        else if (GameControl_PowerBalanceMode.gameControl.player[0].PlayerScore == GameControl_PowerBalanceMode.gameControl.player[1].PlayerScore)
        {
            Player2Text.text = "Draw!";
            Player1Text.text = "Draw!";
        }
    }
	
    
}
