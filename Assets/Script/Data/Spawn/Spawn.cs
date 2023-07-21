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
    public float spawnPatrolX { get; }
    public float spawnPatrolY { get; }
    public float spawnPatrolEdges { get; }
    public float spawnWallX { get; }
    public float spawnWallY { get; }

    public Spawn(string spawnID, string mobID, int mobHp, int mobXPDrop, string weaponID,
        string mobBehaviour, float spawnPatrolX, float spawnPatrolY, float spawnPatrolEdges,
        float spawnWallX, float spawnWallY)
    {
        this.spawnID = spawnID;
        this.mobID = mobID;
        this.mobHp = mobHp;
        this.mobXPDrop = mobXPDrop;
        this.weaponID = weaponID;
        this.mobBehaviour = mobBehaviour;
        this.spawnPatrolX = spawnPatrolX;
        this.spawnPatrolY = spawnPatrolY;
        this.spawnPatrolEdges = spawnPatrolEdges;
        this.spawnWallX = spawnWallX;
        this.spawnWallY = spawnWallY;
    }
}
