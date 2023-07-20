using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn
{
    public string spawnID { get; }
    public string mobID { get; }
    public int mobHp { get; }
    public int mobXPDrop { get; }
    public string weaponID { get; }
    public string mobBehaviour { get; }
    public float spawnPatrol { get; }
    public float spawnPatrolLeft { get; }
    public float spawnPatrolRight { get; }

    public Spawn(string spawnID, string mobID, int mobHp, int mobXPDrop, string weaponID, string mobBehaviour, float spawnPatrol, float spawnPatrolLeft, float spawnPatrolRight)
    {
        this.spawnID = spawnID;
        this.mobID = mobID;
        this.mobHp = mobHp;
        this.mobXPDrop = mobXPDrop;
        this.weaponID = weaponID;
        this.mobBehaviour = mobBehaviour;
        this.spawnPatrol = spawnPatrol;
        this.spawnPatrolLeft = spawnPatrolLeft;
        this.spawnPatrolRight = spawnPatrolRight;
    }
}
