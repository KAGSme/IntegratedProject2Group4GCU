using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Debug_Android : MonoBehaviour {

    // allows for us to easily change a piece of text on the new gui to log events that occur

    public static Debug_Android debugAOS;

    public bool isActive = true;
    int logNumber = 0;
    Text debugtext;
    

    void Awake()
    {
        if (debugAOS == null) debugAOS = this; else if (debugAOS != this) DestroyObject(this.gameObject);
        debugtext = gameObject.GetComponent<Text>();
    }

    public void Output(string dText)
    {
        if (isActive)
        {
            logNumber++;
            debugtext.text = dText + " " + Convert.ToString(logNumber);
        }
    }

}
