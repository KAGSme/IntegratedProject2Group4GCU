﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Timer1 : MonoBehaviour {

    public float timer;
    public GameControl_PowerBalanceMode gameController;
    Text timerText;
    public GameObject timerActive;

	// Use this for initialization
	void Start () 
    {
        timerText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Timer();
        timerText.text = Convert.ToString(Mathf.Round(timer));
	}
    void Timer()
    {
        if (gameController.state == State.Running)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            timer = 0;
            gameController.state = State.End;
        }
        if (gameController.state == State.End)
        {
            timerActive.active = false;
        }

    }


}
