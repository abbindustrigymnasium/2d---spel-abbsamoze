using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public Rigidbody2D gameobject;
    public int playerspeed = 10;
    private bool facingright = true;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update() 
    {
        PlayerMove();
    }
    
    void PlayerMove(){
        //Controls
        moveX = Input.GetAxisRaw("Horizontal"); 
        if (Input.GetButtonDown("Jump")){
            Jump();
        }
        //Animations 

        //Player direction
        if (moveX < 0.0f && facingright == false) {
            FlipPlayer();
        } else if (moveX > 0.0f && facingright == true) {
            FlipPlayer();
        };
        //Physics
       gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerspeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);   

    }

    void Jump(){
        //Jump code
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
    }

    void FlipPlayer(){
        facingright = !facingright;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisonEnter2D (Collision2D col){
        Debug.Log("Player has collided with" + col.collider.name);
        if (col.gameObject.tag == "ground") {
            isGrounded = true;
        }
    }
};
