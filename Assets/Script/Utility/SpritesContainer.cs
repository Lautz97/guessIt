using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesContainer : MonoBehaviour {

    public static SpritesContainer sprites = null;

    // Use this for initialization
    void Awake() {
        if (sprites == null) {
            DontDestroyOnLoad(gameObject);
            sprites = this;
        }
        else if (sprites != this) {
            DestroyImmediate(gameObject);
        }
    }

    public GameObject baseObj;

    public Sprite playButton, quitButton, optionsButton, plusButton, minusButton, menuButton;

    public Sprite[] numbers = new Sprite[10];

    public Sprite checkButton, resetButton;
    public Sprite wrongPosition, rightPosition;

    public Sprite On;
    public Sprite Off;

}

