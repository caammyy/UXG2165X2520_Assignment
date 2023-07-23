using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    //body variables
    private Animator ani;
    private Rigidbody2D rb;

    //player variables
    public string currentCharacterID;
    public int currentCharacterHp;
    public string currentCharacterName;
    public string currentCharacterWeaponID;

    public Player currentPlayer;
    public PlayerLevel currentPlayerLevel;
    public int currentLevel;

    public int playerXP;
    private float playerDamage;
    public int playerHealth;
    public float currentHealth;

    private playerUI playerUI;
    private playerTutorial playerTut;
    private endDoor endDoor;
     
    private void Start()
    {
        playerUI = GameObject.Find("/Canvas/PlayerUI").GetComponent<playerUI>();
        SetPlayer();
        SetPlayerVariables();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        SetLevel();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")){
            StartCoroutine(playerTut.defText("You must defeat the slimes before carrying on!", 3));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            playerTut.InitializeNextTutorial();
        }
        else if (collision.gameObject.CompareTag("EndDoor"))
        {
            endDoor.NextLevel();
        }
    }
    public void Hurt(float dmg)
    {
        currentHealth = Mathf.Clamp(currentHealth - dmg, 0, playerHealth);
        //GameObject.Find("/Canvas/Healthbar").GetComponent<playerHealthbar>().playerHealth 
        ani.SetTrigger("hurt");
        if (currentHealth == 0f)
        {
            ani.SetBool("death", true);

            rb.bodyType = RigidbodyType2D.Static;

            GetComponent<Collider2D>().enabled = false;
        }
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SetPlayer()
    {
        List<Player> pList = Game.GetPlayerList();
        if (!PlayerPrefs.HasKey("PlayerID"))
        {
            string newPlayerID;
            if (pList.Count > 0)
            {
                Player lastPlayer = pList[pList.Count - 1];
                newPlayerID = lastPlayer.playerID.Remove(0, 1);
                if (Int32.Parse(newPlayerID) > 8)
                {
                    newPlayerID = "P" + Int32.Parse(newPlayerID) + 1;
                }
                else
                {
                    newPlayerID = "P0" + Int32.Parse(newPlayerID) + 1;
                }
            }
            else
            {
                newPlayerID = "P01";
            }
            currentPlayer = new Player(DateTime.Now, newPlayerID, currentCharacterID, 0, 1);
        }
        else
        {
            foreach (Player p in pList)
            {
                if (p.playerID == PlayerPrefs.GetString("PlayerID"))
                {
                    currentPlayer = p;
                }
            }
        }
        playerUI.currentCharacter = currentPlayer.playerCharacterID;
        playerUI.currentPlayerName = currentCharacterName;
    }

    void SetPlayerVariables()
    {
        SetLevel();
        //set initial player health
        playerHealth = currentCharacterHp + currentPlayerLevel.levelHP;
        currentHealth = playerHealth;

        //set initial player damage
        List<Weapon> wList = Game.GetWeaponList();
        foreach (Weapon w in wList)
        {
            if (w.weaponID == currentCharacterWeaponID)
            {
                playerDamage = currentPlayerLevel.levelAD + w.damageAmount;
                break;
            }
        }

        GameObject.Find("/Canvas/Healthbar").GetComponent<playerHealthbar>().playerHealth = this;
        GameObject.Find("/Main Camera").GetComponent<cameraController>().player = transform;
        playerTut = GameObject.Find("Canvas").GetComponent<playerTutorial>();
        endDoor = GameObject.Find("EndDoor").GetComponent<endDoor>();

    }
    void SetLevel()
    {
        //set initial player level
        if (playerXP == 0)
            playerXP = currentPlayer.playerXP;
        List<PlayerLevel> plList = Game.GetPlayerLevelList();

        playerUI.plList = plList;
        foreach (PlayerLevel pl in plList)
        {
            if (playerXP < pl.levelXP)
            {
                currentLevel = pl.levelNo;
                currentPlayerLevel = pl;
                break;
            }
        }
        playerUI.currentPlayerLevel = currentLevel;
        playerUI.currentPlayerXP = playerXP;
    }
}
