using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cammy
public class Mob
{
    public string mobID { get; }
    public string mobType { get; }


    public Mob(string mobID, string mobType)
    {
        this.mobID = mobID;
        this.mobType = mobType;
    }
}
