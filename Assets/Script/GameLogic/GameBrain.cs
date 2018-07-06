using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBrain : MonoBehaviour {

	GameObject[] CpuMarbles;
	GameObject[] UserMarbles;

	Palette colorPalette;

    /**
     * associate to this script the current marble set and palette
     */
	public void Associate(GameObject[] cpuMar, GameObject[] userMar,Palette pal){
		CpuMarbles = cpuMar;
		UserMarbles = userMar;
		colorPalette = pal;
	}


    /**
     * returns the state of the game
     * true == you won
     * false == keep trying
     */
    public bool Check() {

        Vector2 result = CheckFunction(CpuMarbles, UserMarbles);
        Debug.Log(result);
        if(result.x == UserMarbles.Length) {
            return true;
        }
        
        return false;
    }

    /**
     * returns the Vector2 composed like this (posOk,colOk)
     */
    public Vector2 CheckFunction() {
        return CheckFunction(CpuMarbles, UserMarbles);
    }

    /**
     * return a Vector2 composed like this (posOk,colOk)
     */
	Vector2 CheckFunction (GameObject[] cpuMar, GameObject[] userMar){
		
		int len = userMar.Length;
		int posOk = 0;
		int colOk = 0;

		int[] check = new int[len];
		for (int i = 0; i < len; i++) {
			check [i] = 1;
		}

		for (int i = 0; i < len; i++) {
			if (Color.Equals(userMar [i].GetComponent<SpriteRenderer> ().color, cpuMar [i].GetComponent<SpriteRenderer> ().color)) {
				posOk++;
				check [i] = 0;
			}
		}

		int[] check2 = new int[len];
		for (int i = 0; i < len; i++) {
			check2 [i] = check[i];
		}

		for (int i = 0; i < len; i++) {
			for (int j = 0; j < len; j++) {
				
				if (Color.Equals(userMar [i].GetComponent<SpriteRenderer> ().color, 
					cpuMar [j].GetComponent<SpriteRenderer> ().color) && check [i] == 1 && check2 [j] == 1) {
					colOk++;
					check [i] = 0;
					check2 [j] = 0;
				}
			}
		}
		return new Vector2 (posOk, colOk);
	}


	int selected = 0;

	/**
	 * change the color of the currently selected marble
	 * passing "+1" means next
	 * passing "-1" means previous
	 */
	public void ColorChange(int direction){
		if (direction == -1) {
			colorPalette.Previous (UserMarbles [selected].GetComponent<SpriteRenderer> ());
		} else if (direction == 1) {
			colorPalette.Next (UserMarbles [selected].GetComponent<SpriteRenderer> ());
		}
	}

	/**
	 * change the currently selected marble
	 * passing "+1" means next
	 * passing "-1" means previous
	 */
	public void SelectedChange(int direction){
		
		if (direction == -1) {
			if (selected == 0) {
				selected = UserMarbles.Length - 1;
			} else
				selected--;
		} else if (direction == 1) {
			if (selected == UserMarbles.Length - 1) {
				selected = 0;
			} else
				selected++;
		}
	}

    /**
	 * change the currently selected marble by indexing
	 */
    public void SetSelected(int i){
		selected = i;
	}
}
