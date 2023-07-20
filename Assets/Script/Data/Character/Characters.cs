using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//from JY W8 Demo 1 
public class Characters  
{
    public string characterID { get; }
    public string characterName { get; }
    public int characterHp { get; }
    public string weaponID { get; }


    public Characters(string characterID, string characterName, int characterHp, string weaponID)
    {
        this.characterID = characterID;
        this.characterName = characterName;
        this.characterHp = characterHp;
        this.weaponID = weaponID;
    }

}
