using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataScript
{
    // vvvv these names should follow our excel sheet page names vvvv
    public List<RefCharacter> Characters;
    public List<RefMob> Mob;
    public List<RefWeapon> Weapons;
    public List<RefDialogue> alwyndialogue;
}
