using UnityEngine;
using System.Collections;

public class GraphicRotation : MonoBehaviour {

    [Range( -30, 30)]
    public float rotation;
    public bool moveToOrigin = true;

    void Start()
    {

    }

	// Update is called once per frame
	void Update () {
        if (gameObject.transform.localPosition != new Vector3(0, 0, 0) && moveToOrigin)
        {
            transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, new Vector3(0, 0, 0), 2.0f * Time.deltaTime);
            float distance = Vector3.Magnitude(gameObject.transform.localPosition - new Vector3(0, 0, 0));
            if (distance < 0.01f) { gameObject.transform.localPosition = new Vector3(0, 0, 0); }
        }

        gameObject.transform.Rotate(new Vector3(0,0,rotation));
	}
}
