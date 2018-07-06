using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButton : MonoBehaviour {

    [Tooltip ("This MUST be the name of the called method")]
    string type;

    GameControl gc = null;

	public void Setgc(GameControl con){
		gc = con;
	}

    public void SetType(string t) {
        type = t;
    }

	void OnMouseDown () {
		
        Invoke(type, 0);

    }

    void Check() {
        if (gc != null) {
            gc.Check();
        }
    }

    void NextColor() {

        if (gc != null) {
            gc.Clicked(int.Parse(gameObject.name.Remove(0, 10)));
        }

    }

    void Reset() {

        SceneManager.LoadSceneAsync("Game");

    }

    void Play() {

        SceneManager.LoadSceneAsync("Game");

    }

    void Quit() {

        Application.Quit();

    }

    void Home() {

        SceneManager.LoadSceneAsync("Menu");

    }

    void Options() {

        SceneManager.LoadSceneAsync("Options");

    }

    void MarblesNumber() {
        if(gameObject.name=="More Marbles") {
            ShortTermMemory.memory.ChangeMarblesNumber(1);
        }else if(gameObject.name == "Less Marbles") {
            ShortTermMemory.memory.ChangeMarblesNumber(-1);
        }
        GameObject.Find("OptionsContainer").GetComponent<OptionsSceneManager>().SetNumericals();
        if (Application.isEditor) {
            Debug.Log(ShortTermMemory.memory.ChangeMarblesNumber(0));
        }
    }

    void ColorsNumber() {
        if (gameObject.name == "More Colors") {
            ShortTermMemory.memory.ChangeColorsNumber(1);
        }
        else if (gameObject.name == "Less Colors") {
            ShortTermMemory.memory.ChangeColorsNumber(-1);
        }
        GameObject.Find("OptionsContainer").GetComponent<OptionsSceneManager>().SetNumericals();
        if (Application.isEditor) {
            Debug.Log(ShortTermMemory.memory.ChangeColorsNumber(0));
        }
    }

}
