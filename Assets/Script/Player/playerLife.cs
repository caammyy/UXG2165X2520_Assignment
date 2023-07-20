using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rb;

    [SerializeField] private float initialHealth;
    public float currentHealth { get; private set; }

    [SerializeField] playerTutorial playerTut;
    [SerializeField] endDoor endDoor;
     
    private void Awake()
    {
        currentHealth = initialHealth;

    }
    private void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

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
        currentHealth = Mathf.Clamp(currentHealth - dmg, 0, initialHealth);
        ani.SetTrigger("hurt");
        if (currentHealth == 0f)
        {
            ani.SetBool("death", true);
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
