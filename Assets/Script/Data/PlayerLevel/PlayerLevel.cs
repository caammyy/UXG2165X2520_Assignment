using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel
{
    public int levelNo { get; }
    public int levelXP{ get; }
    public float levelAD { get; }
    public int levelHP { get; }

    public PlayerLevel(int levelNo, int levelXP, float levelAD, int levelHP)
    {
        this.levelNo = levelNo;
        this.levelXP = levelXP;
        this.levelAD = levelAD;
        this.levelHP = levelHP;
    }
}
