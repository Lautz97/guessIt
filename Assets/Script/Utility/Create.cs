using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour {

    //the base marble prefab
    [Tooltip("this is the base prefab")]
    public GameObject baseMarble;

    public static Create create = null;

    void Awake() {
        if (create == null) {
            DontDestroyOnLoad(gameObject);
            create = this;
        }
        else if (create != this) {
            DestroyImmediate(gameObject);
        }
    }

    public GameObject GenerateButton(string name, Sprite sprite, float xPos, float yPos, string method) {
        GameObject obj = Instantiate(baseMarble);
        obj.name = name;
        obj.GetComponent<SpriteRenderer>().sprite = sprite;
        Vector2 pos = new Vector2(xPos, yPos);
        obj.transform.position = pos;
        //obj.GetComponent<ClickButton>().Setgc(gameObject.GetComponent<GameControl>());
        obj.GetComponent<ClickButton>().SetType(method);
        return obj;
    }

    public GameObject GenerateSprite(string name, Sprite sprite, float xPos, float yPos) {
        GameObject obj = Instantiate(baseMarble);
        obj.name = name;
        obj.GetComponent<SpriteRenderer>().sprite = sprite;
        Vector2 pos = new Vector2(xPos, yPos);
        obj.transform.position = pos;
        //obj.GetComponent<ClickButton>().Setgc(gameObject.GetComponent<GameControl>());
        return obj;
    }


}
