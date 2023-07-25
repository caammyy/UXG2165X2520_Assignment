using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.AddressableAssets;



public class DataManager : MonoBehaviour
{
    /**
     * og data
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
    **/

    public void LoadRefData(Action onLoaded)
    {
        StartCoroutine(DoLoadRefData("Demodata", onLoaded));
    }

    public IEnumerator DoLoadRefData(string path, Action Onloaded)
    {
        bool processing = true;
        string loadedText = "";

        Addressables.LoadAssetAsync<TextAsset>(path).Completed += (op) =>
        {
            loadedText = op.Result.text;
            processing = false;
        };

        while (processing)
        {
            yield return null;
        }

        DataScript datascript = JsonUtility.FromJson<DataScript>(loadedText);
        processData(datascript);
        Onloaded?.Invoke();
    }

    public T ReadData<T>(string filepath)
    {
        string datastring = File.ReadAllText(filepath);
        T Data = JsonUtility.FromJson<T>(datastring);
        //Debug.Log(datastring);
        return Data;
    }

    public void WriteData<T>(string filepath, T data)
    {
        string datastring = JsonUtility.ToJson(data);
        File.WriteAllText(filepath, datastring);
    }


    public void processData(DataScript dataScript)
    {
        //characters
        List<Characters> characterList = new List<Characters>();
        foreach (RefCharacters refcharacter in dataScript.Characters)
        {
            Characters character = new Characters(refcharacter.characterID, refcharacter.characterName, refcharacter.characterHp, refcharacter.weaponID);
            characterList.Add(character);
        }
        Game.SetCharacterList(characterList);


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
            Spawn spawn = new Spawn(refspawn.spawnID, refspawn.mobID, refspawn.mobHp, refspawn.mobXPDrop, refspawn.weaponID, refspawn.mobBehaviour, refspawn.spawnPatrolX, refspawn.spawnPatrolY, refspawn.spawnPatrolEdges, refspawn.spawnWallX, refspawn.spawnWallY, refspawn.spawnFrequency);
            spawnList.Add(spawn);
        }
        Game.SetSpawnList(spawnList);


        //weapon
        List<Weapon> weaponList = new List<Weapon>();
        foreach (RefWeapon refweapon in dataScript.Weapon)
        {
            Weapon weapon = new Weapon(refweapon.weaponID, refweapon.weaponName, refweapon.weaponDamageAmount, refweapon.weaponAttackRange, refweapon.weaponAttackRate, refweapon.weaponType);
            weaponList.Add(weapon);
        }
        Game.SetWeaponList(weaponList);


        //dialogue
        List<Dialogue> dialogueList = new List<Dialogue>();
        foreach (RefDialogue refdialogue in dataScript.Dialogue)
        {
            Dialogue dialogue = new Dialogue(refdialogue.cutsceneRefID, refdialogue.nextcutsceneRefID, refdialogue.cutsceneSetID,
                refdialogue.currentSpeaker, refdialogue.leftSpeaker, refdialogue.rightSpeaker, refdialogue.leftImage, refdialogue.rightImage,
                refdialogue.leftEmotion, refdialogue.rightEmotion, refdialogue.dialogue, refdialogue.choices);
            dialogueList.Add(dialogue);
        }
        Game.SetDialogueList(dialogueList);
 

        //gamelevel
        List<GameLevel> gamelevelList = new List<GameLevel>();
        foreach (RefGameLevel refgamelevel in dataScript.GameLevel)
        {
            GameLevel gamelevel = new GameLevel(refgamelevel.gameLevelID, refgamelevel.gameSpawnPointX, refgamelevel.gameSpawnPointY, refgamelevel.gameEndPointX, refgamelevel.gameEndPointY);
            gamelevelList.Add(gamelevel);
        }
        Game.SetGameLevelList(gamelevelList);


        //playerlevel
        List<PlayerLevel> playerlevelList = new List<PlayerLevel>();
        foreach (RefPlayerLevel refplayerlevel in dataScript.PlayerLevel)
        {
            PlayerLevel playerlevel = new PlayerLevel(refplayerlevel.levelNo, refplayerlevel.levelXP, refplayerlevel.levelAD, refplayerlevel.levelHP);
            playerlevelList.Add(playerlevel);
        }
        Game.SetPlayerLevelList(playerlevelList);

        //player
        List<Player> playerList = new List<Player>();
        foreach (RefPlayer refPlayer in dataScript.Player)
        {
            Player player = new Player(refPlayer.playerID, refPlayer.playerCreation, refPlayer.playerCharacterID, refPlayer.playerXP, refPlayer.playerLevelNo, refPlayer.playerWeaponID, refPlayer.playerEnemiesKilled, refPlayer.playerDamageTaken, refPlayer.playerShortestTimeTakenSection);
            playerList.Add(player);
        }
        Game.SetPlayerList(playerList);

        //scene
        List<Scene> sceneList = new List<Scene>();
        foreach (RefScene refScene in dataScript.Scene)
        {
            Scene scene = new Scene(refScene.sceneName, refScene.cutSceneSetID, refScene.gameLevelID);
            sceneList.Add(scene);
        }
        Game.SetSceneList(sceneList);
    }
}
