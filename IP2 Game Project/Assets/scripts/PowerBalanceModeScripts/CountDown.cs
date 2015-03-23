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

    void OnEnable()
    {
        GameControl_PowerBalanceMode.gameControl.gameStart += Timer;
    }

    void OnDisable()
    {
        GameControl_PowerBalanceMode.gameControl.gameStart -= Timer;
    }

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
