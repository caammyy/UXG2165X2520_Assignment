using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public DateTime playerCreation { get; }
    public string playerID { get; }
    public string playerCharacterID { get; }
    public int playerXP { get; }
    public int playerLevelNo { get; }


    public Player(DateTime playerCreation, string playerID, string playerCharacterID, int playerXP, int playerLevelNo)
    {
        this.playerCreation = playerCreation;
        this.playerID = playerID;
        this.playerCharacterID = playerCharacterID;
        this.playerXP = playerXP;
        this.playerLevelNo = playerLevelNo;
    }
}
