using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadRefData();
    }

    public void LoadRefData()
    {
        string filePath = Path.Combine(Application.dataPath, "Script/Data/jsonData.txt");
        //persistent data path is for when you want to save the game data(?), data path is for the data alr inside unity

        string dataString = File.ReadAllText(filePath);
        Debug.Log(dataString);

        DataScript dataScript = JsonUtility.FromJson<DataScript>(dataString);

        processData(dataScript);
    }
    
    private void processData(DataScript dataScript)
    {
        //characters
        List<Character> characterList = new List<Character>();
        foreach (RefCharacter refcharacter in dataScript.Characters)
        {
            Character character = new Character(refcharacter.characterID, refcharacter.characterName,  
                refcharacter.characterHp, refcharacter.weaponID);
            characterList.Add(character);
        }
        Game.SetCharacterList (characterList);

        //mob
        List<Mob> mobList = new List<Mob>();
        foreach (RefMob refmob in dataScript.Mob)
        {
            Mob mob = new Mob(refmob.mobID, refmob.mobType, refmob.mobHp, refmob.weaponID);
            mobList.Add(mob);
        }
        Game.SetCharacterList(characterList);

        //weapon
        List<Weapon> weaponList = new List<Weapon>();
        foreach (RefWeapon refweapon in dataScript.Weapons)
        {
            Weapon weapon = new Weapon(refweapon.weaponID, refweapon.weaponName, refweapon.damageAmount);
            weaponList.Add(weapon);
        }
        Game.SetCharacterList(characterList);

        //dialogue
        List<Dialogue> dialogueList = new List<Dialogue>();
        foreach (RefDialogue refdialogue in dataScript.alwyndialogue)
        {
            Dialogue dialogue = new Dialogue(refdialogue.cutsceneRefID, refdialogue.nextcutsceneRefID, refdialogue.cutsceneSetID,
                refdialogue.currentSpeaker, refdialogue.leftSpeaker, refdialogue.rightSpeaker, refdialogue.leftImage, refdialogue.rightImage, 
                refdialogue.dialogue, refdialogue.choices);
            dialogueList.Add(dialogue);
        }
        Game.SetDialogueList(dialogueList);
    }
}
