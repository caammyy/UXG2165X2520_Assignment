using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ashley
public class Weapon
{
    public string weaponID { get; }
    public string weaponName { get; }
    public float weaponDamageAmount{ get; }
    public float weaponAttackRange { get; }
    public float weaponAttackRate { get; }
    public string weaponType { get; }


    public Weapon(string weaponID, string weaponName, float weaponDamageAmount, float weaponAttackRange, float weaponAttackRate, string weaponType)
    {
        this.weaponID = weaponID;
        this.weaponName = weaponName;
        this.weaponDamageAmount = weaponDamageAmount;
        this.weaponAttackRange = weaponAttackRange;
        this.weaponAttackRate = weaponAttackRate;
        this.weaponType = weaponType;
    }
}
