// Player movement and sprite flipping + animation code taken from https://youtu.be/pYu36PLmdq0?si=73RweqBqEnpRApcs and https://youtu.be/Sg_w8hIbp4Y?si=0snSYHyHd8lIdDUd - Anna M.

using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{

    float horizontalInput;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private float input;
    bool isFacingRight = false;
    float jumpPower = 5f;
    bool isJumping = false;



    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal"); //A, D, and Left and Right Arrow keys

        if (!PauseController.IsGamePaused)
        {
            FlipSprite();
        }
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isJumping = true;
        }

        //Old Movement code
        /*float moveInput = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            moveInput = -1f;
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            moveInput = 1f;
        }

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); */
    }

    void FixedUpdate()
    {
        if (PauseController.IsGamePaused)
        {
            rb.linearVelocity = Vector2.zero; //Stop movement
            animator.SetFloat("xVelocity", 0f);
            return;
        }
        else
        {
            rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
            animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        }
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }
    /*
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Player entered " + col.name);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Player exited " + col.name);
    }
    */
}
