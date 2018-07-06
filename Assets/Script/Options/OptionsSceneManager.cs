using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsSceneManager : MonoBehaviour {

    //utility handle
    ScreenBounds bounds;
    float vDelta;
    float fvPos;

    float hDelta;
    float fmp;

    GameObject marbNum = null, colNum = null;

    [Tooltip("this is the base prefab")]
    public GameObject baseMarble;

    [Tooltip("The Graphic of the GUI button")]
    public Sprite plus, minus, playButton, menuButton;

    public Sprite[] numerical = new Sprite[10];

    // Use this for initialization
    void Start() {
        bounds = GameObject.Find("Main Camera").GetComponent<ScreenBounds>();

        GenerateUIObjects();
    }

    void GenerateUIObjects() {

        vDelta = ((bounds.GetTopLimit() * 2) / 8);
        fvPos = bounds.GetBottomLimit() + vDelta * 2;

        hDelta = (bounds.GetRightLimit() * 2f) / (3);
        fmp = bounds.GetLeftLimit() + hDelta;

        Create.create.GenerateButton("Play", playButton, fmp, fvPos, "Play");

        Create.create.GenerateButton("Menu", menuButton, fmp + hDelta, fvPos, "Menu");

        fvPos += vDelta;

        Create.create.GenerateButton("More Marbles", plus, fmp, fvPos + 2 * vDelta, "MarblesNumber");

        Create.create.GenerateButton("Less Marbles", minus, fmp, fvPos, "MarblesNumber");

        Create.create.GenerateButton("More Colors", plus, fmp + hDelta, fvPos + 2 * vDelta, "ColorsNumber");

        Create.create.GenerateButton("Less Colors", minus, fmp + hDelta, fvPos, "ColorsNumber");

        SetNumericals();
    }

    public void SetNumericals() {
        Destroy(marbNum);
        marbNum = Create.create.GenerateSprite("Marble Number", numerical[ShortTermMemory.memory.ChangeMarblesNumber(0)], fmp, fvPos + vDelta);

        Destroy(colNum);
        colNum = Create.create.GenerateSprite("Color Number", numerical[ShortTermMemory.memory.ChangeColorsNumber(0)], fmp + hDelta, fvPos + vDelta);
    }




}
