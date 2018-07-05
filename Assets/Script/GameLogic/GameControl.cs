using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	GameBrain gb;

	ManageScene sm;

	public void Start(){

		gb = gameObject.GetComponent<GameBrain> ();
		sm = gameObject.GetComponent<ManageScene> ();
	
	}

    /**
	public void Update () {
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			gb.ColorChange(-1);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			gb.ColorChange(1);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			gb.SelectedChange(1);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			gb.SelectedChange(-1);
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			sm.SlideUp ();
		}
	}//*/

	public void Clicked(int i){
		gb.SetSelected (i);
		gb.ColorChange (1);
	}

	public void Check() {

        if (!gb.Check()) sm.SlideUp();

        if (gb.Check()) {
            sm.SlideUp();
            GameObject.Find("check").SetActive(false);
        }
        
    }














    


	/**
	public void clicked(string dir) {
	
		switch (dir) {
		case "up" :
			cp.next (UserMarbles [selected].GetComponent<SpriteRenderer> ());
			break;
		case "down" :
			cp.previous (UserMarbles [selected].GetComponent<SpriteRenderer> ());
			break;
		case "rx":
			if (selected == UserMarbles.Length - 1) {
				selected = 0;
			} else
				selected++;
			break;
		case "lx" :
			if (selected == 0) {
				selected = UserMarbles.Length - 1;
			} else
				selected--;
			break;
		case "ok":
			resultAnalizer ();//result = gb.setMarbles (UserMarbles);
			break;
		default:
			break;
		}
	
	}*/
	/*
	void resultAnalizer(){
		//result = gb.setMarbles (UserMarbles);
		Debug.Log ("in posizione corretta: " + result.x);
		Debug.Log ("colore corretto ma non in posizione: " + result.y);
		if (result.x == UserMarbles.Length) {
			Debug.Log ("you won");
		}
	}*/
}
