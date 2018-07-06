using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {

    //utility handle
    ScreenBounds bounds;

    [Tooltip("this is the base prefab")]
    public GameObject baseMarble;

    [Tooltip("The Graphic of the GUI button")]
    public Sprite playButton, quitButton, optionsButton;

    // Use this for initialization
    void Start () {
        bounds = GameObject.Find("Main Camera").GetComponent<ScreenBounds>();

        GenerateUIObjects();
    }


    /**
    * generate some utilities
    */
    void GenerateUIObjects() {

        float fvPos = bounds.GetBottomLimit() + ((bounds.GetTopLimit() * 2) / 2);
        //float vDelta = 1;
        float hDelta = (bounds.GetRightLimit() * 2f) / (3);
        float fmp = bounds.GetLeftLimit() + hDelta;

        Create.create.GenerateButton("Play", playButton, fmp, fvPos, "Play");

        Create.create.GenerateButton("Quit", quitButton, fmp + hDelta, fvPos, "Quit");

        Create.create.GenerateButton("Options", optionsButton, fmp + (hDelta/2), fvPos, "Options");

    }

    /**
     * i have to make this static and accessable
     */ 
    GameObject __GenerateButton(string name, Sprite sprite, float xPos, float yPos, string method) {
        GameObject obj = Instantiate(baseMarble);
        obj.name = name;
        obj.GetComponent<SpriteRenderer>().sprite = sprite;
        Vector2 pos = new Vector2(xPos, yPos);
        obj.transform.position = pos;
        //obj.GetComponent<ClickButton>().Setgc(gameObject.GetComponent<GameControl>());
        obj.GetComponent<ClickButton>().SetType(method);
        return obj;
    }

}
