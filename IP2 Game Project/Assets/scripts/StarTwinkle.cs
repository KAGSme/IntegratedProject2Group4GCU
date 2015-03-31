using UnityEngine;
using System.Collections;

public class StarTwinkle : MonoBehaviour {

	public float waitingTime=0.05f;
	IEnumerator Start ()
	{
		while (true)
		{
			light.enabled = !(light.enabled); //star on and off
			yield return new WaitForSeconds(waitingTime);
		}
	}

}
