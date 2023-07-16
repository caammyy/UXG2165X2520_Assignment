using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.TextCore.Text;
using UnityEditor.VersionControl;


public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //LoadRefData();
    }
    public T ReadData<T>(string filepath)
    {
        string datastring = File.ReadAllText(filepath);
        T Data = JsonUtility.FromJson<T>(datastring);
        //Debug.Log(datastring);
        return Data;
    }
    public void LoadRefData()
    {
        string filePath = Path.Combine(Application.dataPath, "Script/Data/jsonData2.txt");
        //persistent data path is for when you want to save the game data(?), data path is for the data alr inside unity

        //string dataString = File.ReadAllText(filePath);
        //Debug.Log(dataString);
        DataScript dataScript = ReadData<DataScript>(filePath);
       // DataScript dataScript = JsonUtility.FromJson<DataScript>(dataString);

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
            Mob mob = new Mob(refmob.mobID, refmob.mobType);
            mobList.Add(mob);
        }
        Game.SetMobList(mobList);

        //spawn
        List<Spawn> spawnList = new List<Spawn>();
        foreach (RefSpawn refspawn in dataScript.Spawn)
        {
            Spawn spawn = new Spawn(refspawn.spawnID, refspawn.spawnName, refspawn.mobID, refspawn.mobHp, refspawn.mobXPDrop, refspawn.weaponID, refspawn.mobBehaviour);
            spawnList.Add(spawn);
        }
        Game.SetSpawnList(spawnList);

        //weapon
        List<Weapon> weaponList = new List<Weapon>();
        foreach (RefWeapon refweapon in dataScript.Weapons)
        {
            Weapon weapon = new Weapon(refweapon.weaponID, refweapon.weaponName, refweapon.damageAmount);
            weaponList.Add(weapon);
        }
        Game.SetWeaponList(weaponList);

        //dialogue
        List<Dialogue> dialogueList = new List<Dialogue>();
        foreach (RefDialogue refdialogue in dataScript.Dialogue)
        {
            Dialogue dialogue = new Dialogue(refdialogue.cutsceneRefID, refdialogue.nextcutsceneRefID, refdialogue.cutsceneSetID,
                refdialogue.currentSpeaker, refdialogue.leftSpeaker, refdialogue.rightSpeaker, refdialogue.leftImage, refdialogue.rightImage, 
                refdialogue.dialogue, refdialogue.choices);
            dialogueList.Add(dialogue);
        }
        Game.SetDialogueList(dialogueList);
        //Debug.Log(Game.GetDialogueList().Count);

        //gamelevel
        List<GameLevel> gamelevelList = new List<GameLevel>();
        foreach (RefGameLevel refgamelevel in dataScript.GameLevel)
        {
            GameLevel gamelevel = new GameLevel(refgamelevel.gameLevelID, refgamelevel.cutsceneSetID);
            gamelevelList.Add(gamelevel);
        }
        Game.SetGameLevelList(gamelevelList);

        //playerlevel
        List<PlayerLevel> playerlevelList = new List<PlayerLevel>();
        foreach (RefPlayerLevel refplayerlevel in dataScript.PlayerLevel)
        {
            PlayerLevel playerlevel = new PlayerLevel(refplayerlevel.playerLevelID, refplayerlevel.levelXP);
            playerlevelList.Add(playerlevel);
        }
        Game.SetPlayerLevelList(playerlevelList);
    }
}
