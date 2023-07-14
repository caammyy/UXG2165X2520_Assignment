using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel
{
    public int gameLevelID { get; }
    public int cutsceneSetID { get; }

    public GameLevel(int gameLevelID, int cutsceneSetID)
    {
        this.gameLevelID = gameLevelID;
        this.cutsceneSetID = cutsceneSetID;
    }
}
