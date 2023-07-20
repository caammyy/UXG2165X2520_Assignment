using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel
{
    public int gameLevelID { get; }
    public int cutsceneSetID { get; }
    public float gameSpawnPoint { get; }
    public float gameEndPoint { get; }

    public GameLevel(int gameLevelID, int cutsceneSetID, float gameSpawnPoint, float gameEndPoint)
    {
        this.gameLevelID = gameLevelID;
        this.cutsceneSetID = cutsceneSetID;
        this.gameSpawnPoint = gameSpawnPoint;
        this.gameEndPoint = gameEndPoint;
    }
}
