using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{ 
    
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

    private static List<Dialogue> dialogueList;

    public static List<Dialogue> GetDialopgueList()
    {
        return dialogueList;
    }
}
