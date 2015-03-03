using UnityEngine;
using System.Collections;

public class Timer2 : MonoBehaviour {

    public GameControl_PowerBalanceMode gameController;
    private float rotAngle = -90;
    private Vector2 pivotPoint;
    public float timer;
    public GUIStyle timerStyle;
    public State state;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer();

    }
    void Timer()
    {
        if (gameController.state == State.Running)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
            timer = 0;
    }

    void OnGUI()
    {
        if (gameController.state == State.Running)
        {
            pivotPoint = new Vector2(Screen.width / 2, Screen.height/2);
            GUIUtility.RotateAroundPivot(rotAngle, pivotPoint);
            GUI.Label(new Rect(pivotPoint.x, pivotPoint.y, 200, 400), "" + Mathf.RoundToInt(timer), timerStyle);

        }
    }
}
