using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cammy
public class Player
{
    public DateTime playerCreation { get; }
    public string playerID { get; }
    public string playerCharacterID { get; }
    public int playerXP { get; }
    public int playerLevelNo { get; }
    public string playerWeaponID { get; }
    public int playerEnemiesKilled { get; }
    public float playerDamageTaken { get; }
    public float playerShortestTimeTakenSection { get; }


    public Player(DateTime playerCreation, string playerID, string playerCharacterID, int playerXP, int playerLevelNo, string playerWeaponID, int playerEnemiesKilled, float playerDamageTaken, float playerShortestTimeTakenSection)
    {
        this.playerCreation = playerCreation;
        this.playerID = playerID;
        this.playerCharacterID = playerCharacterID;
        this.playerXP = playerXP;
        this.playerLevelNo = playerLevelNo;
        this.playerWeaponID = playerWeaponID;
        this.playerEnemiesKilled = playerEnemiesKilled;
        this.playerDamageTaken = playerDamageTaken;
        this.playerShortestTimeTakenSection = playerShortestTimeTakenSection;
    }

    public DateTime GetPlayerCreation()
    {
        return playerCreation;
    }
    
    public string GetPlayerID()
    {
        return playerID;
    }

    public string GetPlayerCharacterID()
    {
        return playerCharacterID;
    }

    public int GetPlayerXP()
    {
        return playerXP;
    }

    public int GetPlayerLevelNo()
    {
        return playerLevelNo;
    }

    public string GetPlayerWeaponID()
    {
        return playerWeaponID;
    }

    public int GetPlayerEnemiesKilled()
    {
        return playerEnemiesKilled;
    }

    public float GetPlayerDamageTaken()
    {
        return playerDamageTaken;
    }

    public float GetPlayerShortestTimeTakenSection()
    {
        return playerShortestTimeTakenSection;
    }



}

