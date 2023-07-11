using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadRefData();
    }

    public void LoadRefData()
    {
        string filePath = Path.Combine(Application.dataPath, "Script/Data/dialogueTestData.txt");
        //persistent data path is for when you want to save the game data(?), data path is for the data alr inside unity

        string dataString = File.ReadAllText(filePath);
        Debug.Log(dataString);

        DataScript datascript = JsonUtility.FromJson<DataScript>(dataString);
    }
}
