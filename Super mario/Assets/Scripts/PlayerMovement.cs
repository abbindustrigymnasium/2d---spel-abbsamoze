using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public Rigidbody2D gameobject;
    public int playerspeed = 10;
    public bool facingright = true;
    public int playerJumpPower = 1250;
    public float moveX;
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
    }

    void FlipPlayer(){
        facingright = !facingright;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
};
