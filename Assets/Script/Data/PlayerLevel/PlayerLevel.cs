using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel
{
    public int playerLevelID { get; }
    public int levelXP{ get; }

    public PlayerLevel(int playerLevelID, int levelXP)
    {
        this.playerLevelID = playerLevelID;
        this.levelXP = levelXP;
    }
}
