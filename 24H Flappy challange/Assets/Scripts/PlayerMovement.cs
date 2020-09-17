using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip jumpSound;
    private Animator animator;
    private new Rigidbody2D rigidbody;
    public float movementSpeed;
    public float jumpForce;

    private int score;
    public TMP_Text scoreText;

    private void Start()
    {
        score = 0;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        scoreText.text = score.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
            animator.SetBool("IsJumping", true);
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
            rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
        if(rigidbody.velocity.y < 0 & transform.rotation.eulerAngles.z < 90)
        {
            float rotationAngle = rigidbody.velocity.y;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, -rotationAngle * 9));
        }
        if(rigidbody.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        if(movementSpeed < 6f)
        {
            movementSpeed += 0.01f * Time.deltaTime;
        }    
    }
    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(movementSpeed, rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ++score;
    }

    private void GameOver()
    {
        Destroy(gameObject);
    }
}
