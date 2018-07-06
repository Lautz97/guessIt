using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 * This Class make an Object Persistant and UNIQUE through all scenes
 * 
 */
public class PersistantObj : MonoBehaviour {

    public static GameObject persist = null;

	// Use this for initialization
	void Awake () {
        if (persist == null) {
            DontDestroyOnLoad(gameObject);
            persist = gameObject;
        }else if(persist != gameObject) {
            DestroyImmediate(gameObject);
        }
	}
	
}
