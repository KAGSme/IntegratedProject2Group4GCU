using UnityEngine;
using System.Collections;

public class PowerUp_Base : MonoBehaviour {

    public float coolDown = 10f;
    public float planetEnergyActivation = 15.0f;
    private bool isActive;
    public float stationaryTouchSpeed = 0.5f;
    public Planet planet;
    public GameObject planetObject;

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
        PowerActivation();
	}
    
    float lastTimeCheck = 0f;
    void CoolDownCheck()
    {
        float timer = Time.timeSinceLevelLoad;
        if (timer - lastTimeCheck >= coolDown)
        {
            isActive = false;
            lastTimeCheck = timer;
        }
    }

    void PowerActivation()
    {
        if (planet.energy <= planetEnergyActivation && IsActive == false)
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch touch = Input.GetTouch(i);
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    Debug.Log("touchDetected");
                    
                    if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                    {
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.gameObject == this && touch.deltaPosition.magnitude <= stationaryTouchSpeed)
                            {
                                IsActive = true;
                                CoolDownCheck();
                            }
                        }
                    }
                }
            }
        }
                                
    }
}
