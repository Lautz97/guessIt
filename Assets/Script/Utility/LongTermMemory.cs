using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LongTermMemory : MonoBehaviour {

    public static LongTermMemory memory = null;

    string dataPath;

    // Use this for initialization
    void Awake() {
        dataPath = Application.persistentDataPath + "/playerInfo.dat";
        if (memory == null) {
            DontDestroyOnLoad(gameObject);
            memory = this;
        }
        else if (memory != this) {
            DestroyImmediate(gameObject);
        }
    }

    public  void Save() {
        Debug.Log("Save");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(dataPath);

        PlayerData data = new PlayerData();

        /*data.numberOfMarbles = ShortTermMemory.memory.ChangeMarblesNumber(0);
        data.numberOfColors = ShortTermMemory.memory.ChangeColorsNumber(0);*/

        Debug.Log(data.numberOfColors + "/n" + data.numberOfMarbles);

        bf.Serialize(file, data);

        file.Close();

    }

    public void Load() {
        Debug.Log("Load");
        PlayerData data;
        if (File.Exists(dataPath)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(dataPath, FileMode.Open);

            data = (PlayerData)bf.Deserialize(file);

            file.Close();

            Debug.Log(data.numberOfColors + "/n" + data.numberOfMarbles);

        }
        else { data = new PlayerData(); }

        ShortTermMemory.memory.SetNumberOfColors(data.numberOfColors);
        ShortTermMemory.memory.SetNumberOfMarbles(data.numberOfMarbles);
        ShortTermMemory.memory.SetSpacing(data.spacing);

        UserActionsSceneManager.manager.LoadScene("Menu");

    }

    public void Reset() {
        File.Delete(dataPath);
        
    }


}

[Serializable]
class PlayerData 
{
    public int numberOfMarbles;
    public int numberOfColors;
    public bool spacing;

    
    public PlayerData () {
        numberOfMarbles = ShortTermMemory.memory.ChangeMarblesNumber(0);
        numberOfColors = ShortTermMemory.memory.ChangeColorsNumber(0);
        spacing = ShortTermMemory.memory.GetSpacing();

        if (numberOfMarbles == 0) numberOfMarbles = 6;
        if (numberOfColors == 0) numberOfColors = 4;
    }
    
}