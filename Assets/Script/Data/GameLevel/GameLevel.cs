using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ashley
public class GameLevel
{
    public int gameLevelID { get; }
    public float gameSpawnPointX { get; }
    public float gameSpawnPointY { get; }
    public float gameEndPointX { get; }
    public float gameEndPointY { get; }

    public GameLevel(int gameLevelID, float gameSpawnPointx, float gameSpawnPointY, float gameEndPointX, float gameEndPointY)
    {
        this.gameLevelID = gameLevelID;
        this.gameSpawnPointX = gameSpawnPointx;
        this.gameSpawnPointY = gameSpawnPointY;
        this.gameEndPointX = gameEndPointX;
        this.gameEndPointY = gameEndPointY;
    }
}
