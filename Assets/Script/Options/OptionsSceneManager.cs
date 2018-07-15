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

    public GameObject baseMarble;
        
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

        Create.create.GenerateButton("Play", SpritesContainer.sprites.playButton, fmp, fvPos, "Play");

        Create.create.GenerateButton("Menu", SpritesContainer.sprites.menuButton, fmp + hDelta, fvPos, "Home");

        fvPos += vDelta;

        Create.create.GenerateButton("More Marbles", SpritesContainer.sprites.plusButton, fmp, fvPos + 2 * vDelta, "MarblesNumber");

        Create.create.GenerateButton("Less Marbles", SpritesContainer.sprites.minusButton, fmp, fvPos, "MarblesNumber");

        Create.create.GenerateButton("More Colors", SpritesContainer.sprites.plusButton, fmp + hDelta, fvPos + 2 * vDelta, "ColorsNumber");

        Create.create.GenerateButton("Less Colors", SpritesContainer.sprites.minusButton, fmp + hDelta, fvPos, "ColorsNumber");

        if (ShortTermMemory.memory.GetSpacing()) {
            Create.create.GenerateButton("Spacing", SpritesContainer.sprites.On, 0, 0, "Spacing");
        }
        else {
            Create.create.GenerateButton("Spacing", SpritesContainer.sprites.Off, 0, 0, "Spacing");
        }

        SetNumericals();
    }

    public void SetNumericals() {
        Destroy(marbNum);
        marbNum = Create.create.GenerateSprite ("Marble Number", SpritesContainer.sprites.numbers[ShortTermMemory.memory.ChangeMarblesNumber(0)], fmp, fvPos + vDelta);

        Destroy(colNum);
        colNum = Create.create.GenerateSprite ("Color Number", SpritesContainer.sprites.numbers[ShortTermMemory.memory.ChangeColorsNumber(0)], fmp + hDelta, fvPos + vDelta);
    }




}
