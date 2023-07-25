using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    string currentCharacterSelected;
    [SerializeField] private TMP_Text currentCharacter;
    [SerializeField] private Button proceed;

    private int selectedCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCharacterSelected != null)
        {
            currentCharacter.text = "Selected Character: " + currentCharacterSelected;
            proceed.gameObject.SetActive(true);
        }
    }
    public void onCharacterSelected()
    {
        currentCharacterSelected = EventSystem.current.currentSelectedGameObject.name;
    }
    public void proceedCharacter()
    {
        if (currentCharacterSelected != null)
        {
            List<Characters> cList = Game.GetCharacterList();
            foreach (Characters c in cList)
            {
                if (c.characterName == currentCharacterSelected)
                {
                    Debug.Log(c.characterID);
                    PlayerPrefs.SetString("characterID", c.characterID);
                }
            }
            SceneManager.LoadScene("Level_0");
        }
    }
}
