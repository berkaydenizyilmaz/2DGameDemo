using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    Rigidbody2D characterRigidbody;
    Animator animator;
    Vector3 velocity;

    [SerializeField] float jumpForce;
    [SerializeField] float speed;

    int diamondCount = 0;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovementControl();
    }

    // Karakter hareketini saðlar
    private void MovementControl()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += velocity * speed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && characterRigidbody.velocity.y == 0)
        {
            animator.SetBool("isJumping", true);
            characterRigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

        if (animator.GetBool("isJumping") && characterRigidbody.velocity.y == 0)
        {
            animator.SetBool("isJumping", false);
        }

        if (velocity.x == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
       
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-1, 1);
        }
    }

    // Çarpýþma kontrolleri
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Diamond'a çarparsa score arttýrma
        if (collision.CompareTag("Diamond"))
        {
            Diamond diamond = collision.GetComponent<Diamond>();
            if (diamond != null)
            {
                diamond.Collect();  

                diamondCount++;
                Debug.Log("Diamond count: " + diamondCount);
            }
        }
    }

    // Toplanan elmas sayýsýný döndürür
    public int GetDiamondCount()
    {
        return diamondCount;
    }
}