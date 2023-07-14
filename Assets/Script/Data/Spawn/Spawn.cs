using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn
{
    public string spawnID { get; }
    public string spawnName { get; }
    public string mobID { get; }
    public int mobHp { get; }
    public int mobXPDrop { get; }
    public string weaponID { get; }
    public string mobBehaviour { get; }

    public Spawn(string spawnID, string spawnName, string mobID, int mobHp, int mobXPDrop, string weaponID, string mobBehaviour)
    {
        this.spawnID = spawnID;
        this.spawnName = spawnName;
        this.mobID = mobID;
        this.mobHp = mobHp;
        this.mobXPDrop = mobXPDrop;
        this.weaponID = weaponID;
        this.mobBehaviour = mobBehaviour;
    }
}
