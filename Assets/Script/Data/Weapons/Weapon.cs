using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public string weaponID { get; }
    public string weaponName { get; }
    public int damageAmount{ get; }


    public Weapon(string weaponID, string weaponName, int damageAmount)
    {
        this.weaponID = weaponID;
        this.weaponName = weaponName;
        this.damageAmount = damageAmount;
    }
}
