using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float crouchSpeed = 2f; // Speed while crouching

    private bool isJumping = false;
    private bool isCrouching = false;
    private Rigidbody2D rb;
    private Animator animator;
    private bool facingRight = true;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Crouch") && !isJumping)
        {
            isCrouching = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
        }

        if (isCrouching)
        {
            moveX *= crouchSpeed;
        }

        Vector2 movement = new Vector2(moveX, 0);

        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(moveX));
        animator.SetBool("isCrouching", isCrouching);
        animator.SetBool("isJumping", isJumping);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        // Flip the character to face the direction of movement
        if (moveX > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveX < 0 && facingRight)
        {
            Flip();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Azul") || collision.gameObject.CompareTag("Rojo"))
        {
            isJumping = false;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}