using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player_movement_script : MonoBehaviour
{
    public Animator animator;

    private float horizontal;
    private float speed = 8f;
    private float JumpPower = 14f;
    private bool isFacingRight = true;
    public Text WinText;


    private bool doubleJump;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public FuitManager fm;

    // Update is called once per frame

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(isGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;   // conditia de double jump
        }

        if (Input.GetButtonDown("Jump") && (isGrounded() || doubleJump))
        {
            
            rb.velocity = new Vector2(rb.velocity.x, JumpPower); 
            // actualizeaza pozitia pentru a sari dublu


            doubleJump = !doubleJump;
            // actualizeaza conditia daca poate sari
        }
        
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); 
            // actualizeaza pozitia pentru a sari
        }
        
        Flip();  // apeleaza algoritmul care intoarce pozitia caracterului



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single); 
            // iese in meniu
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        // merge in directia dorita


        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x)); 
        // foloseste animatia pentru mers

    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);
        // verifica daca carcacterul este pe pamant si poate sari
    }
    private void Flip()
    {
        if (isFacingRight && horizontal > 0f || isFacingRight == false && horizontal < 0f)
        {
            // algoritmul care determina modificarea orientarii caracterului

            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }


    }

    private void Start()
    {
        WinText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "WIN" )
        {
            WinText.gameObject.SetActive(true);
            
         
        }



        if(other.gameObject.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
            fm.FruitCount++;
        }
    }
}
