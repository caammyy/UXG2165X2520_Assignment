using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob
{
    public string mobID { get; }
    public string mobType { get; }
    public int mobHp { get; }
    public string weaponID { get; }


    public Mob(string mobID, string mobType, int mobHp, string weaponID)
    {
        this.mobID = mobID;
        this.mobType = mobType;
        this.mobHp = mobHp;
        this.weaponID = weaponID;
    }
}
