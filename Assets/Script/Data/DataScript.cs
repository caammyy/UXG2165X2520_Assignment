using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataScript
{
    // vvvv these names should follow our excel sheet page names vvvv
    public List<RefDialogue> Dialogue;
    public List<RefCharacter> Characters;
    public List<RefMob> Mob;
    public List<RefSpawn> Spawn;
    public List<RefWeapon> Weapons;
    public List<RefGameLevel> GameLevel;
    public List<RefPlayerLevel> PlayerLevel;
}
