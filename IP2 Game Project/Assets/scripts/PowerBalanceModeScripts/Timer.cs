using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour {

    public float timer;
    public State stateSwitch;
    public Text timerText;
    public bool isStartCountdownTimer;
	
    // Use this for initialization
	void Start () 
    {
        timerText = GetComponent<Text>();

        if (isStartCountdownTimer == true)
        {
            Debug.Log("Onenable");
            GameControl_PowerBalanceMode.gameControl.gameStart += CountdownTimer;
        }
        else
        {
            GameControl_PowerBalanceMode.gameControl.gameRun += CountdownTimer;
        }
    }

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
	void Update () 
    {
        timerText.text = Convert.ToString(Mathf.Round(timer));
	}
    void CountdownTimer()
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
