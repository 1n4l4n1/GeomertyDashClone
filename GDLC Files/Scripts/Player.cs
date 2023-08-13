using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour{

    public float gravity = -9.8f;
    public float jumpStrength = 10f;
    private Vector3 direction;
    public float jumpForce = 5f;
    public float moveSpeed = 1f;

    public bool isGrounded = false;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool isDoor = false;
    public RestartButtonText RestartButtonText;

    Rigidbody2D rb2d;

    AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
    }

   
    void Update(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (groundCheck != null){
            isGrounded = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.CompareTag("Deadly")){
            audioManager.PlaySFX(audioManager.damage);
            Debug.Log("dead");
            RestartLevel();
        }
        
        if (collision.gameObject.CompareTag("Door")){
            isDoor = true;
        }

        if (collision.gameObject.CompareTag("WinDoor")){
            isDoor = true;
            SceneManager.LoadScene("StartMenu");
        }

        

    }

    private void FixedUpdate(){
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

        if (!isDoor){
            if (isGrounded){
                if(Input.GetMouseButtonDown(0)){
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                }
            }

            
        }

        else{
            if (Input.GetMouseButtonDown(0)){
                rb2d.velocity = new Vector2((gravity * Time.fixedDeltaTime), jumpStrength); 
            }
        }
        
    }

    public void RestartLevel(){
        RestartButtonText.Setup();
    }

   
}
