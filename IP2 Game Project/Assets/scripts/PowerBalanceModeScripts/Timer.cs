using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour{ // This class deals with the functionality associated with the timer in the game

    public float timer;
    public State stateSwitch;
    public Text timerText;
    public bool isStartCountdownTimer;
    public AudioClip audioTicker;
	
    // Use this for initialization
	void Start () 
    {
        timerText = GetComponent<Text>();
        
        if (isStartCountdownTimer == true)
        {
            Debug.Log("Onenable");
            GameControl_PowerBalanceMode.gameControl.gameStart += CountdownTimer; //Delegate the CountdownTimer function to gameStart
        }
        else
        {
            GameControl_PowerBalanceMode.gameControl.gameRun += CountdownTimer; //Delegate the CountdownTimer function to gameRun
        }
    }
    //When the script is disabled if there is a gameControl object and the isStartCountdownTimer is true, undelegate the CountdownTimer function from the gameStart. Else if the isStartCountdownTimer
    //is false, undelegate the CountdownTimer function from the gameRun.
    void OnDisable()
    {
        if (GameControl_PowerBalanceMode.gameControl != null && isStartCountdownTimer == true)
        {
            GameControl_PowerBalanceMode.gameControl.gameStart -= CountdownTimer;
        }
        else if (GameControl_PowerBalanceMode.gameControl != null && isStartCountdownTimer == false)
        {
            GameControl_PowerBalanceMode.gameControl.gameRun -= CountdownTimer;
        }
    }
	
	// Update is called once per frame
	void Update () //Rounds the timer value and puts it to a string. And plays the audio ticker clip.
    {
        timerText.text = Convert.ToString(Mathf.Round(timer));

        if (audioTicker != null && timer <= audioTicker.length)
        {
            if (!audio.isPlaying)
            {
                audio.clip = audioTicker;
                audio.Play();
            }

        }
	}
    void CountdownTimer() //Counts down once per second, when the timer value reaches 0 it will change the state of the game, and set the timer object off.
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 0;
            GameControl_PowerBalanceMode.gameControl.GameStateSwitch(stateSwitch);
            timerText.gameObject.SetActive(false);
        }
    }
}
