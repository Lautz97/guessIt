using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //LongTermMemory.memory.Reset();

        LongTermMemory.memory.Load();
        
    }
    
}
