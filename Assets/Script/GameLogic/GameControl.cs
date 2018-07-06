using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	GameBrain gb;

	ManageScene sm;

    bool victory = false;

	public void Start(){

		gb = gameObject.GetComponent<GameBrain> ();
		sm = gameObject.GetComponent<ManageScene> ();
	
	}

    /**
     * change the color of the clicked marble
     */
	public void Clicked(int i){

        if (!victory) {
            gb.SetSelected(i);
            gb.ColorChange(1);
        }

    }

    /**
     * check for game state (victory or not) and slide up marbles if the code is not correct or trigger win actions
     */
	public void Check() {

        if (!gb.Check()) sm.SlideUp();

        if (gb.Check()) {
            victory = true;
            sm.SlideUp();
            GameObject.Find("Check").SetActive(false);
        }
        
    }

    
}
