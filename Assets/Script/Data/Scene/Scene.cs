using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene
{
    public string sceneName { get; }
    public int cutSceneSetID { get; }
    public int gameLevelID { get; }
    public Scene(string sceneName, int cutSceneSetID, int gameLevelID)
    {
        this.sceneName = sceneName;
        this.cutSceneSetID = cutSceneSetID;
        this.gameLevelID = gameLevelID;
    }
}
