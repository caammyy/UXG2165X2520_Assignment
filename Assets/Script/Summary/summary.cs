using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class summary : MonoBehaviour
{
    [SerializeField] private TMP_Text playerID;
    [SerializeField] private Image playerSprite;
    [SerializeField] private TMP_Text playerLevel;
    [SerializeField] private TMP_Text playerXP;
    [SerializeField] private TMP_Text playerAD;
    [SerializeField] private TMP_Text playerHP;
    [SerializeField] private TMP_Text playerEnemiesKilled;
    [SerializeField] private TMP_Text playerDamageTaken;
    [SerializeField] private TMP_Text playerTimeTaken;


    // Start is called before the first frame update
    void Start()
    {
        Player player = Game.GetPlayer();
        playerID.text = player.playerID;
        playerLevel.text = player.playerLevelNo.ToString();
        playerXP.text = player.playerXP.ToString();
        playerEnemiesKilled.text = player.playerEnemiesKilled.ToString();
        playerDamageTaken.text = player.playerDamageTaken.ToString();
        //ad
        float ad = 0f;
        int hp = 0;
        string chara = "";
        List <PlayerLevel> plList = Game.GetPlayerLevelList();
        foreach (PlayerLevel pl in plList)
        {
            if (pl.levelNo == player.playerLevelNo)
            {
                ad += pl.levelAD;
                hp += pl.levelHP;
            }
        }
        List<Characters> cList = Game.GetCharacterList();
        foreach (Characters c in cList)
        {
            if (c.characterID == player.playerCharacterID)
            {
                hp += c.characterHp;
                chara = c.characterName;
            }
        }
        List<Weapon> wList = Game.GetWeaponList();
        foreach (Weapon w in wList)
        {
            if (w.weaponID == player.playerWeaponID)
            {
                ad += w.weaponDamageAmount;
            }
        }
        playerAD.text = ad.ToString();
        playerHP.text = hp.ToString();

        AssetManager.LoadSprite((chara + ".png"), (Sprite s) =>
        {
            playerSprite.sprite = s;
        });
        playerTimeTaken.text = player.playerShortestTimeTakenSection.ToString();
    }

    public void GoNextScene()
    {
        SceneManager.LoadScene("dialogue");
    }
}
