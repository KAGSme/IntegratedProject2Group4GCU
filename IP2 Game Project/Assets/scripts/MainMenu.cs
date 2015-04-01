using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
  //  public float swipeSpeed = 3f;
	public GameObject button;
    public Image energyBar;
    string status;
	// Use this for initialization
	void Start () {
        energyBar.fillAmount = 0.5f;
        


	}
	
	// Update is called once per frame
	void Update () {
        PlayerSwipe();
        if (energyBar.fillAmount >= 1)
        {
            energyBar.fillAmount = 1;
            Application.LoadLevel(1);
        }
	}

    public void Play()
    {
        Application.LoadLevel(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    void PlayerSwipe()
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
                                status = "hit";
                            }
                        }
                        break;
                }
            }
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), status);
    }


}
