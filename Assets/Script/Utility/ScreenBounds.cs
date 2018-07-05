using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour {

	public float GetBottomLimit( ) {
		return -gameObject.GetComponent<Camera> ().orthographicSize;
	}

	public float GetTopLimit( ) {
		return gameObject.GetComponent<Camera> ().orthographicSize;
	}

	public float GetRightLimit( ) {
		return gameObject.GetComponent<Camera>().orthographicSize * Screen.width / Screen.height;
	}

	public float GetLeftLimit( ) {
		return -gameObject.GetComponent<Camera>().orthographicSize * Screen.width / Screen.height;
	}


}
