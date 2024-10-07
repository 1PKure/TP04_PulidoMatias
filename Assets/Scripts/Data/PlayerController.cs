using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float life = 100;
    */
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Set(PlayerData playerData)
    {
        this.playerData = playerData;
    }

    void Update()
    {
        rb.AddForce(new Vector2(playerData.moveSpeed, 0));

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, playerData.jumpForce), ForceMode2D.Impulse);
            animator.SetTrigger("Jumped");
            jumpSound.Play();

        }
    }


    public void SetMovementSpeed(float newSpeed)
    {
        if (newSpeed > 1)
        {
            return;
        }
        playerData.moveSpeed = newSpeed * Time.deltaTime * 1000;
    }

    public float GetMovementSpeed()
    {
        return playerData.moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isGrounded", isGrounded);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Te chocaste con el obstaculo");
            playerData.life -= 10;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

