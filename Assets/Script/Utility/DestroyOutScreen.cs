using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutScreen : MonoBehaviour {

    float top, bot, rx, lx;

	void Start () {
        ScreenBounds b = GameObject.Find("Main Camera").GetComponent<ScreenBounds>();
        bot = b.GetBottomLimit();
        top = b.GetTopLimit();
        rx = b.GetRightLimit();
        lx = b.GetLeftLimit();
	}

    /**
     * destroy everything got this when it goes off sight
     * but this is not a clever method
     */
    private void Update() {
        if (transform.position.x > rx || transform.position.x < lx || transform.position.y > top || transform.position.y < bot) {
            Destroy(gameObject);
        }
    }

}
