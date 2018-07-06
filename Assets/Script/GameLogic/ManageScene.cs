﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScene : MonoBehaviour {

    //utility handle
    ScreenBounds bounds;
    Palette colorPalette;

    //cointainers of marbles in the scene
    GameObject cpuContainer;
    GameObject userContainer;
    GameObject marbleContainer;
    GameObject pointContainer;
    GameObject buttonContainer;
    GameObject uiContainer;

    //the base marble prefab
    [Tooltip("this is the base prefab")]
    public GameObject baseMarble;

    //arrays of cpu and user marbles
    GameObject[] CpuMarbles;
    GameObject[] UserMarbles;

    //debug units
    [Tooltip("DEBUG this is the number of marbles being spawned")]
    public int numberOfMarbles = 6;
    [Tooltip("DEBUG this is the number of colors being created in the palette")]
    public int paletteLenght = 4;
    [Tooltip("The Graphic of the GUI button")]
    public Sprite checkButton, resetButton, homeButton;
    public Sprite color, position;

	void Start () {

        //set containers
        marbleContainer = new GameObject("Marbles");
        buttonContainer = new GameObject("Buttons");
        uiContainer = new GameObject("UserInterface");

        //utility handle setting
        colorPalette = Palette.palette;
        bounds = GameObject.Find("Main Camera").GetComponent<ScreenBounds>();

        //generate palette
        paletteLenght = ShortTermMemory.memory.ChangeColorsNumber(0);
        colorPalette.GeneratePalette(paletteLenght);

        //generate user and cpu marbles and positioning
        numberOfMarbles = ShortTermMemory.memory.ChangeMarblesNumber(0);
        GenerateSet();

	}



	/**
	 * initialize the marble set
	 */
	void GenerateSet () { 

        cpuContainer = new GameObject("Cpu");
        cpuContainer.transform.parent = marbleContainer.transform;

        userContainer = new GameObject("User");
        userContainer.transform.parent = marbleContainer.transform;

        GenerateMarbleSet(numberOfMarbles);

        gameObject.GetComponent<GameBrain>().Associate(CpuMarbles, UserMarbles, colorPalette);

        GenerateUIObjects();

        Points();
    }

    /**
     * generate all obj in the scene
     */
	void GenerateMarbleSet(int n){

        GenerateCpuMarbleSet(n);
        GenerateUserMarbleSet(n);

    }

    /**
    * generate some utilities
    */
    void GenerateUIObjects() {

        float fvPos = bounds.GetBottomLimit() + ((bounds.GetTopLimit() * 2) / 3);
        float vDelta = 1;
        float hDelta = (bounds.GetRightLimit() * 2f) / (4);
        float fmp = bounds.GetLeftLimit() + hDelta;

        GameObject tempHandle;

        tempHandle = Create.create.GenerateButton("Check", checkButton, fmp + hDelta, fvPos, "Check");
        tempHandle.transform.parent = buttonContainer.transform;
        tempHandle.GetComponent<ClickButton>().Setgc(gameObject.GetComponent<GameControl>());

        hDelta = (bounds.GetRightLimit() * 2f) / (5);
        fmp = bounds.GetLeftLimit() + 2 * hDelta;

        tempHandle = Create.create.GenerateButton("Reset", resetButton, fmp, fvPos - vDelta, "Reset");
        tempHandle.transform.parent = buttonContainer.transform;
        tempHandle.GetComponent<ClickButton>().Setgc(gameObject.GetComponent<GameControl>());

        tempHandle = Create.create.GenerateButton("Home", homeButton, fmp + hDelta, fvPos - vDelta, "Home");
        tempHandle.transform.parent = buttonContainer.transform;
        tempHandle.GetComponent<ClickButton>().Setgc(gameObject.GetComponent<GameControl>());

    }

    /**
     * usefull class to generate button with interaction over the Click Button interface
     */
    GameObject __GenerateButton(string name, Sprite sprite, float xPos, float yPos, string method) {
        GameObject obj = Instantiate(baseMarble);
        obj.name = name;
        obj.GetComponent<SpriteRenderer>().sprite = sprite;
        Vector2 pos = new Vector2(xPos, yPos);
        obj.transform.position = pos;
        obj.GetComponent<ClickButton>().Setgc(gameObject.GetComponent<GameControl>());
        obj.GetComponent<ClickButton>().SetType(method);
        return obj;
    }


    /**
     * generate the marble of the user each call a new one
     */
    void GenerateUserMarbleSet(int n){

        UserMarbles = new GameObject[n];

        float delta = (bounds.GetRightLimit() * 2f) / (n + 1f);
        float fmp = bounds.GetLeftLimit() + delta;
        float verPos = bounds.GetBottomLimit() + ((bounds.GetTopLimit() * 2) / 2);

		for (int i = 0; i < n; i++) {

            UserMarbles[i] = Instantiate(baseMarble, userContainer.transform);
            UserMarbles[i].name = "userMarble" + i;
            UserMarbles[i].GetComponent<SpriteRenderer>().color = colorPalette.GetZeroColor();

            Vector2 pos = new Vector2(fmp + delta * i, verPos);

            UserMarbles[i].transform.position = pos;

            ClickButton cb = UserMarbles[i].GetComponent<ClickButton>();

            cb.Setgc(gameObject.GetComponent<GameControl>());

            cb.SetType("NextColor");
        }
	}

    /**
     * generate a marble set passing a preexistent one... gemini function of GenerateUserMarbleSet
     */
    GameObject[] GenerateUserMarbleSet(int n, GameObject[] um, GameObject uc) {

        GameObject[] newUsMar = new GameObject[n];

        float delta = (bounds.GetRightLimit() * 2f) / (n + 1f);
        float fmp = bounds.GetLeftLimit() + delta;
        float verPos = bounds.GetBottomLimit() + ((bounds.GetTopLimit() * 2) / 2);

        for (int i = 0; i < n; i++) {

            newUsMar[i] = Instantiate(um[i], uc.transform);
            newUsMar[i].name = "userMarble" + i;
            ClickButton cb = newUsMar[i].GetComponent<ClickButton>();
            cb.Setgc(gameObject.GetComponent<GameControl>());
            cb.SetType("NextColor");

            Vector2 pos = new Vector2(fmp + delta * i, verPos);
            newUsMar[i].transform.position = pos;

        }
        return newUsMar;
    }


    /**
     * generate the marble set who has to be guessed with a fixed height...(to not be seen from user)
     */
    void GenerateCpuMarbleSet(int n){

        CpuMarbles = new GameObject[n];

		for (int i = 0; i < n; i++) {

            GameObject newMarble = Instantiate(baseMarble, cpuContainer.transform);
            newMarble.name = "cpuMarble" + i;

            Color col = newMarble.GetComponent<SpriteRenderer>().color;
            col = colorPalette.GetRandomColor();

            newMarble.GetComponent<SpriteRenderer>().color = col;

            CpuMarbles[i] = newMarble;

            CpuMarbles[i].GetComponent<DestroyOutScreen>().enabled = false;

            Vector2 pos = new Vector2(i - n / 2, 10000);
            CpuMarbles[i].transform.position = pos;
		}
	}


    /**
     * slides up the marble set if the code is not guessed and reload points
     */
	public void SlideUp(){

        userContainer.transform.position = new Vector2(0, userContainer.transform.position.y + baseMarble.transform.lossyScale.y);
        //userContainer.transform.localScale = new Vector2(userContainer.transform.lossyScale.x - 0.1f, userContainer.transform.lossyScale.y - 0.1f);

        UserMarbles = GenerateUserMarbleSet(numberOfMarbles, UserMarbles, userContainer);

        gameObject.GetComponent<GameBrain>().Associate(CpuMarbles, UserMarbles, colorPalette);

        DestroyImmediate(pointContainer);

        Points();
	}

    /**
     * the only way i could figure out to tell player if he's right
     */
    void Points() {

        pointContainer = new GameObject();

        pointContainer.transform.parent = uiContainer.transform;

        pointContainer.name = ("point container");

        GameObject posOkContainer = new GameObject();
        posOkContainer.name = ("Correct position container");
        posOkContainer.transform.parent = pointContainer.transform;

        GameObject colOkContainer = new GameObject();
        colOkContainer.name = ("Correct color container");
        colOkContainer.transform.parent = pointContainer.transform;

        float fvPos = bounds.GetBottomLimit() + ((bounds.GetTopLimit() * 2) / 3);
        float vDelta = -0.5f;
        float hDelta = (bounds.GetRightLimit() * 2f) / (6);
        float posOkPos = bounds.GetLeftLimit() + hDelta;

        float posOk = gameObject.GetComponent<GameBrain>().CheckFunction().x;
        float colOk = gameObject.GetComponent<GameBrain>().CheckFunction().y;

        GameObject pawn;

        for(float i = 0; i < posOk; i++) {
            pawn = Create.create.GenerateSprite("posOk" + i, position, posOkPos, fvPos + i * vDelta);
            pawn.transform.parent = pointContainer.transform;
        }

        for (float i = 0; i < colOk; i++) {
            pawn = Create.create.GenerateSprite("colOk" + i, color, -posOkPos, fvPos + i * vDelta);
            pawn.transform.parent = pointContainer.transform;
        }

    }



}
