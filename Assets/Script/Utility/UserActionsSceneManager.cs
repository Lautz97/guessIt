using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserActionsSceneManager : MonoBehaviour {

    public static UserActionsSceneManager manager = null;

    void Awake() {
        if (manager == null) {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this) {
            DestroyImmediate(gameObject);
        }
    }

    public void Quit() {

        Application.Quit();

    }

    public void LoadScene(string obj) {
        SceneManager.LoadSceneAsync(obj);
    }






}
