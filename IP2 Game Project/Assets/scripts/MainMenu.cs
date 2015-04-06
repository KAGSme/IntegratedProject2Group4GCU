using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour{ // This class is going to deal with all the functionality in the Main Menu
    public Image energyBar;

	// Use this for initialization
	void Start () {
        energyBar.fillAmount = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        PlayerSwipe();
        if (energyBar.fillAmount >= 1) // Loads the main level when the bar is full.
        {
            energyBar.fillAmount = 1;
            Application.LoadLevel(1);
        }
	}
    void PlayerSwipe() //Iterates through the touches the device registered and creates a raycast at the location of the touch, and if it detects a planet, it will fill the bar.
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                switch (touch.phase)
                {
                    case (TouchPhase.Moved):
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.gameObject.tag == "PlayerPlanet")
                            {
                                energyBar.fillAmount += 0.5f * Time.deltaTime;
                            }
                        }
                        break;
                }
            }
        }
    }

}
