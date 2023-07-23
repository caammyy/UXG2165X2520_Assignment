using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel
{
    public int gameLevelID { get; }
    public int cutsceneSetID { get; }
    public float gameSpawnPointx { get; }
    public float gameSpawnPointY { get; }
    public float gameEndPointX { get; }
    public float gameEndPointY { get; }

    public GameLevel(int gameLevelID, int cutsceneSetID, float gameSpawnPointx, float gameSpawnPointY, float gameEndPointX, float gameEndPointY)
    {
        this.gameLevelID = gameLevelID;
        this.cutsceneSetID = cutsceneSetID;
        this.gameSpawnPointx = gameSpawnPointx;
        this.gameSpawnPointY = gameSpawnPointY;
        this.gameEndPointX = gameEndPointX;
        this.gameEndPointY = gameEndPointY;
    }
}
