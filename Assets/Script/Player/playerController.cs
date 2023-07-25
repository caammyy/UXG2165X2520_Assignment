using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject playerGO;
    private Characters currentCharacter;
    public Vector3 playerSpawn;
    List<Characters> cList;

    public void SetCharacter()
    {
        cList = Game.GetCharacterList();
        if (!PlayerPrefs.HasKey("characterID"))
        {
            currentCharacter = cList[2];
        }
        else
        {
            foreach (Characters c in cList)
            {
                if (c.characterID == PlayerPrefs.GetString("characterID"))
                    currentCharacter = c;
            }
        }
        AssetManager.LoadPrefabs(currentCharacter.characterName, (GameObject s) =>
        {
            playerGO = s;
            playerGO.name = "Player";
            playerGO.GetComponent<playerLife>().currentCharacterID = currentCharacter.characterID;
            playerGO.GetComponent<playerLife>().currentCharacterHp = currentCharacter.characterHp;
            playerGO.GetComponent<playerLife>().currentCharacterWeaponID = currentCharacter.weaponID;
            playerGO.GetComponent<playerLife>().currentCharacterName = currentCharacter.characterName;

            transform.position = playerSpawn;

            Instantiate(playerGO, transform);

        });
    }
}
