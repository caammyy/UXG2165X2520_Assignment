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

    //weapons
    private static List<Weapon> weaponList;

    public static List<Weapon> GetWeaponList()
    {
        return weaponList;
    }

    public static void SetWeaponList(List<Weapon> cList)
    {
        weaponList = cList;
    }

    //dialogue
    private static List<Dialogue> dialogueList;

    public static List<Dialogue> GetDialogueList()
    {
        return dialogueList;
    }

    public static void SetDialogueList(List<Dialogue> dList)
    {
        dialogueList = dList;
    }

    //DialogueObject
    //getdialogueobjectlist

    //setdialogueobjectlist 

    //getdialoguecharacterlist

    //setdialoguecharacterlist
}
