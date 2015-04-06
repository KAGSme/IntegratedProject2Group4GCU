using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CountDown : MonoBehaviour { 


    public float CountDowntimer = 3;
    public Text timerText;

    // Use this for initialization
    void Start() 
    {
        timerText = GetComponent<Text>();
        timerText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = Convert.ToString(Mathf.Round(CountDowntimer));
    }
    //When the script is enabled delegate the Timer function.
    void OnEnable()
    {
        GameControl_PowerBalanceMode.gameControl.gameStart += Timer;
    }
    //When the script is disabled undelegate the Timer function.
    void OnDisable()
    {
        GameControl_PowerBalanceMode.gameControl.gameStart -= Timer;
    }
    //Counts down from 3. When it reaches 0 changes the game state to "Running", and disables the timerText object;
    void Timer()
    {
        CountDowntimer -= Time.deltaTime;

        if (CountDowntimer <= 0)
        {
            CountDowntimer = 0;
            GameControl_PowerBalanceMode.gameControl.GameState = State.Running;
            timerText.gameObject.SetActive(false);
        }
    }
}
