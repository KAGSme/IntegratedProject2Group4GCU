using UnityEngine;
using System.Collections;
using System;

public enum State { Start, Running, Pause, End};
 
public class GameControl_PowerBalanceMode : MonoBehaviour {

    public static GameControl_PowerBalanceMode gameControl;

    public delegate void gameStateFunctions();
    public gameStateFunctions gameStart;
    public gameStateFunctions gameRun;
    public gameStateFunctions gameEnd;

    private State gameState = State.Start;
    public Player[] player = new Player[2];

    public State GameState
    {
        get{ return gameState; }
        set{ gameState = value; }
    }

    // switches game state... in hindsight this could have been done by just accessing the public property above
    public void GameStateSwitch(State state)
    {
        gameState = state;
    }

    void Awake()
    {
        // singletons design pattern(hopefully)
        if (gameControl == null) gameControl = this; else if(gameControl != this) DestroyObject(this.gameObject);
        Debug.Log("awake");
    }

	// Use this for initialization
	void Start () 
    {
        Time.timeScale = 1;
       
        GameState = State.Start;
	}
	
	// Update is called once per frame
    // gamestates are implemented here
    void Update()
    {
        if (gameStart != null && gameState == State.Start) gameStart();
        if (gameRun != null && GameState == State.Running) gameRun();
        if (gameEnd != null && GameState == State.End) gameEnd();
    }
}
