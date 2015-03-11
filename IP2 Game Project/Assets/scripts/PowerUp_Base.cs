using UnityEngine;
using System.Collections;

public class PowerUp_Base : MonoBehaviour {

    public float coolDown = 10f;
    private bool isActive;
    public Planet planet;

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

	// Use this for initialization
	void Start () {
        isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
        CoolDownCheck();
	}
    
    float lastTimeCheck = 0f;
    void CoolDownCheck()
    {
        if (IsActive == false)
        {
            float timer = Time.timeSinceLevelLoad;
            if (timer - lastTimeCheck >= coolDown)
            {
                isActive = true;
                lastTimeCheck = timer;
            }
        }
    }
}
