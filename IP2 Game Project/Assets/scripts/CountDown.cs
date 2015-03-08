using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CountDown : MonoBehaviour {


    public float timer;
    public GameControl_PowerBalanceMode gameController;
    public Text timerText;

    // Use this for initialization
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        timerText.text = Convert.ToString(Mathf.Round(timer));


    }
    void Timer()
    {
        if (gameController.state == State.Start)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            timer = 0;
            gameController.state = State.Running;
        }
        if (gameController.state == State.Running)
        {
            timerText.active = false;
        }

    }
}
