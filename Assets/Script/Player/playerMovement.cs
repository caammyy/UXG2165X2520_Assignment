using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Cammy
public class playerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D boxCol;
    private SpriteRenderer sprite;
    private Animator ani;

    private GameObject attackPoint;
    private Vector3 left;
    private Vector3 right;

    [SerializeField] private LayerMask jumpGround;
    
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 5f;

    private enum MovementState { idle, walk, jump};

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        attackPoint = GameObject.Find("/GameController/Player(Clone)/attackPoint");
        right = attackPoint.transform.localPosition;
        left = new Vector3(-attackPoint.transform.localPosition.x, attackPoint.transform.localPosition.y);

        sprite.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();

        if (gameObject.transform.position.y <= -4)
        {
            GameObject.Find("Main Camera").GetComponent<cameraController>().transform.position = new Vector3(transform.position.x, -4, -10);
            Invoke("destroyPlayer", 1);
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.walk;
            if (GetComponent<playerLife>().currentCharacterID == "C01")
                sprite.flipX = true;
            else
                sprite.flipX = false;
            attackPoint.transform.localPosition = right;
        }
        else if (dirX < 0f)
        {
            state = MovementState.walk;
            if (GetComponent<playerLife>().currentCharacterID == "C01")
                sprite.flipX = false;
            else
                sprite.flipX = true;
            attackPoint.transform.localPosition = left;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        ani.SetInteger("state", (int)state); 
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }
    void destroyPlayer()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
