using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene
{
    public string sceneName { get; }
    public int cutsceneSetID { get; }
    public int gameLevelID { get; }
    public Scene(string sceneName, int cutsceneSetID, int gameLevelID)
    {
        this.sceneName = sceneName;
        this.cutsceneSetID = cutsceneSetID;
        this.gameLevelID = gameLevelID;
    }
}
