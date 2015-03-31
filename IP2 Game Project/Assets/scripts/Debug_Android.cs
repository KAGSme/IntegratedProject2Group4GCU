using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Debug_Android : MonoBehaviour {

    public static Debug_Android debugAOS;

    int logNumber = 0;
    Text text;
    

    void Awake()
    {
        if (debugAOS == null) debugAOS = this; else if (debugAOS != this) DestroyObject(this.gameObject);

        text = gameObject.GetComponent<Text>();
    }

    public void Output(string debugText)
    {
        logNumber++;
        text.text = debugText + " " + Convert.ToString(logNumber);
    }

}
