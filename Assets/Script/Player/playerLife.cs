using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private List<Weapon> wList;
    private int aniWeapon = 0;
    public int unlockedWeapons = 0;

    public List<Characters> cList;
    public string selectedCharacterName;

    //analytics
    public int currentPlayerEnemiesKilled;
    public float currentPlayerDamageTaken;
    public float currentPlayerShortTime;

    public Player currentPlayer;
    public Player UpdatedPlayer;
    public string currentPlayerID;

    public PlayerLevel currentPlayerLevel;
    public int currentLevel;

    public int playerXP;
    private float playerWeaponDamage;

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
        UpdateCharacter();
        SetLevel();
        if (currentPlayer.playerCharacterID == "C01")
        {
            UpdateKey();
        }
        UpdateWeapon();
        GetComponent<playerAttack>().currentAttackDamage = playerWeaponDamage + currentPlayerLevel.levelAD;
        playerHealth = currentCharacterHp + currentPlayerLevel.levelHP;

        UpdatePlayer();
        
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
            collision.enabled = false;
        }
        else if (collision.gameObject.CompareTag("EndDoor"))
        {
            endDoor.NextLevel();
        }
        else if (collision.gameObject.CompareTag("Weapon"))
        {
            if (currentPlayer.playerCharacterID == "C01")
            {
                aniWeapon = Int32.Parse((collision.gameObject.GetComponent<SpriteRenderer>().sprite.name).Replace("WeaponFloat_", ""));
                GameObject.Find("/Canvas/ItemsPanel/Slot" + (aniWeapon + 1)).SetActive(true);
                GameObject.Find("/Canvas/ItemsPanel/Slot" + (aniWeapon + 1)).GetComponent<Image>().color = (Color)(new Color32(130, 130, 130, 255));
                unlockedWeapons = aniWeapon;
                UpdateWeapon();
            }
            Destroy(collision.gameObject);
        }
    }
    public void Hurt(float dmg)
    {
        currentPlayerDamageTaken += dmg;
        currentHealth = Mathf.Clamp(currentHealth - dmg, 0, playerHealth);
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
            if (pList.Count > 0)
            {
                Player lastPlayer = pList[pList.Count - 1];
                currentPlayerID = lastPlayer.playerID.Remove(0, 1);
                if (Int32.Parse(currentPlayerID) > 8)
                {
                    currentPlayerID = "P" + Int32.Parse(currentPlayerID) + 1;
                }
                else
                {
                    currentPlayerID = "P0" + Int32.Parse(currentPlayerID) + 1;
                }
            }
            else
            {
                currentPlayerID = "P01";
            }
            currentPlayer = new Player(currentPlayerID, DateTime.Now,  currentCharacterID, 0, 1, currentCharacterWeaponID, 0, 0, 0);
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
        wList = Game.GetWeaponList();
        foreach (Weapon w in wList)
        {
            if (w.weaponID == currentCharacterWeaponID)
            {
                GetComponent<playerAttack>().playerWeapon = w;
                playerWeaponDamage = w.weaponDamageAmount;
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
        if (currentLevel != playerUI.currentPlayerLevel)
        {
            playerHealth = currentCharacterHp + currentPlayerLevel.levelHP;
            currentHealth = playerHealth;
        }
        playerUI.currentPlayerLevel = currentLevel;
        playerUI.currentPlayerXP = playerXP;
    }

    void UpdatePlayer()
    {
        
        UpdatedPlayer = new Player(currentPlayer.playerID,currentPlayer.playerCreation, currentCharacterID, playerXP, currentLevel, currentCharacterWeaponID, currentPlayerEnemiesKilled, currentPlayerDamageTaken, currentPlayerShortTime);
        currentPlayer = UpdatedPlayer;
    }

    void UpdateWeapon()
    {
        if (aniWeapon < 10)
        {
            currentCharacterWeaponID = "WC0";
        }
        currentCharacterWeaponID += (aniWeapon+1);

        foreach (Weapon w in wList)
        {
            if (w.weaponID == currentCharacterWeaponID)
            {
                GetComponent<playerAttack>().playerWeapon = w;
                playerWeaponDamage = w.weaponDamageAmount;
                break;
            }
        }
        GetComponent<playerAttack>().animatorWeapon = aniWeapon;
    }
    void UpdateKey()
    {
        if (currentPlayer.playerCharacterID == "C01")
        {
            for (int i = 0; i <= unlockedWeapons; i++)
            {
                GameObject.Find("/Canvas/ItemsPanel/Slot" + (1 + i)).GetComponent<Image>().color = (Color)(new Color32(255, 255, 255, 255));
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                aniWeapon = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (unlockedWeapons >= 1)
                {
                    aniWeapon = 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (unlockedWeapons >= 2)
                {
                    aniWeapon = 2;
                }
            }
            GameObject.Find("/Canvas/ItemsPanel/Slot" + (aniWeapon + 1)).GetComponent<Image>().color = (Color)(new Color32(130, 130, 130, 255));
            UpdateWeapon();
        }
    }
    public void UpdateCharacter()
    {
        cList = Game.GetCharacterList();
        for (int i = 0; i < cList.Count; i++)
        {
            GameObject.Find("/Canvas/CharactersPanel/C0" + (i + 1)).GetComponent<Image>().color = (Color)(new Color32(255, 255, 255, 255));
        }
        if (!(selectedCharacterName == currentCharacterName))
        {
            foreach (Characters c in cList)
            {
                if (selectedCharacterName == c.characterName)
                {
                    currentCharacterHp = c.characterHp;
                    currentCharacterID = c.characterID;
                    currentCharacterWeaponID = c.weaponID;
                    currentCharacterName = c.characterName;
                }
            }
        }
        GameObject.Find("/Canvas/CharactersPanel/" + currentCharacterID).GetComponent<Image>().color = (Color)(new Color32(130, 130, 130, 255));

    }
    
}
