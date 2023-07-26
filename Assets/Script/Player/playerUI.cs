using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Ashley
public class playerUI : MonoBehaviour
{
    public string currentCharacter;
    public string currentPlayerName;
    public int currentPlayerLevel;
    public float currentPlayerXP;
    int requiredPlayerXPtoNext;
    float previousRequiredPlayerXPtoNext = 0;

    public List<PlayerLevel> plList;

    [SerializeField] private Image characterImage;
    [SerializeField] private Image Level_Total;
    [SerializeField] private Image Level_Current;
    [SerializeField] private TMP_Text currentLevel;
    [SerializeField] private TMP_Text XPstoLevel;
    [SerializeField] private TMP_Text currentPlayer;

    // Update is called once per frame
    void Update()
    {

        SetPlayer();
        SetLevel();
    }

    void SetPlayer()
    {
        currentPlayer.text = currentPlayerName;

        SetCharacterImage();

    }
    public void SetLevel()
    {
        if (currentPlayerXP >= requiredPlayerXPtoNext)
            previousRequiredPlayerXPtoNext = requiredPlayerXPtoNext;

        plList = Game.GetPlayerLevelList();
        if (plList != null)
        {
            foreach (PlayerLevel pl in plList)
            {
                if (pl.levelNo == currentPlayerLevel)
                {
                    requiredPlayerXPtoNext = pl.levelXP;
                }
            }

            if (requiredPlayerXPtoNext > 0)
                Level_Total.fillAmount = requiredPlayerXPtoNext / requiredPlayerXPtoNext;

            currentLevel.text = "Level " + currentPlayerLevel;
            XPstoLevel.text = (requiredPlayerXPtoNext - currentPlayerXP) + " to Level " + (currentPlayerLevel + 1);


            if (currentPlayerXP > 0)
            {
                float total = (currentPlayerXP - previousRequiredPlayerXPtoNext) / (requiredPlayerXPtoNext - previousRequiredPlayerXPtoNext);
                Level_Current.fillAmount = total;
            }
            else
            {
                Level_Current.fillAmount = 0;
            }
        }
    }
    void SetCharacterImage()
    {
        if (Game.GetCharacterByCharacterID(currentCharacter) != null)
        {
            Characters c = Game.GetCharacterByCharacterID(currentCharacter);

            string characterImageName = c.characterName + ".png";
            AssetManager.LoadSprite(characterImageName, (Sprite s) =>
            {
                characterImage.sprite = s;
            });
        }
    }
}
