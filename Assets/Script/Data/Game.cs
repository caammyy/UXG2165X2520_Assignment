using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ashley
public static class Game
{ 
    
    //characters
    private static List<Characters> characterList;

    public static List<Characters> GetCharacterList()
    {
        return characterList;
    }

    public static void SetCharacterList(List<Characters> aList)
    {
        characterList = aList;
    }

    public static Characters GetCharacterByCharacterID(string aCharacterID)
    {
        if (characterList != null)
        {
            foreach (Characters a in characterList)
            {
                if (a.characterID == aCharacterID) return a;
            }
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

    //player
    private static Player mainPlayer;

    public static Player GetPlayer()
    {
        return mainPlayer;
    }

    public static void SetPlayer(Player player)
    {
        mainPlayer = player;
    }

    //player list
    private static List<Player> playerList;
    public static List<Player> GetPlayerList()
    {
        return playerList;
    }
    public static void SetPlayerList(List<Player> hList)
    {
        playerList = hList;
    }

    //scene
    private static List<Scene> sceneList;

    public static List<Scene> GetSceneList()
    {
        return sceneList;
    }

    public static void SetSceneList(List<Scene> iList)
    {
        sceneList = iList;
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
