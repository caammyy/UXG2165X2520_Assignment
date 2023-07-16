using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{ 
    
    //characters
    private static List<Character> characterList;

    public static List<Character> GetCharacterList()
    {
        return characterList;
    }

    public static void SetCharacterList(List<Character> aList)
    {
        characterList = aList;
    }

    public static Character GetCharacterByCharacterID(string aCharacterID)
    {
        foreach (Character a in characterList)
        {
            if (a.characterID == aCharacterID) return a;
        }
        return null;
    }

    //mob
    private static List<Mob> mobList;

    public static List<Mob> GetMobList()
    {
        return mobList;
    }

    public static void SetMobList(List<Mob> bList)
    {
        mobList = bList;
    }

    //spawn
    private static List<Spawn> spawnList;

    public static List<Spawn> GetSpawnList()
    {
        return spawnList;
    }

    public static void SetSpawnList(List<Spawn> cList)
    {
        spawnList = cList;
    }

    //weapons
    private static List<Weapon> weaponList;

    public static List<Weapon> GetWeaponList()
    {
        return weaponList;
    }

    public static void SetWeaponList(List<Weapon> dList)
    {
        weaponList = dList;
    }

    //dialogue
    private static List<Dialogue> dialogueList;

    public static List<Dialogue> GetDialogueList()
    {
        return dialogueList;
    }

    public static void SetDialogueList(List<Dialogue> eList)
    {
        dialogueList = eList;
    }



    //game level
    private static List<GameLevel> gamelevelList;

    public static List<GameLevel> GetGameLevelList()
    {
        return gamelevelList;
    }

    public static void SetGameLevelList(List<GameLevel> fList)
    {
        gamelevelList = fList;
    }

    //player level
    private static List<PlayerLevel> playerlevelList;

    public static List<PlayerLevel> GetPlayerLevelList()
    {
        return playerlevelList;
    }

    public static void SetPlayerLevelList(List<PlayerLevel> gList)
    {
        playerlevelList = gList;
    }



    //DialogueObject
    //getdialogueobjectlist


    //setdialogueobjectlist 

    //getdialoguecharacterlist
    /**public static Dialogue GetDialogueCharacterList(string aName)
    {
        return dialogueList.Find(x => x.name == aName);
    }**/

    //setdialoguecharacterlist

    //scale system w diff map systemcx
}
