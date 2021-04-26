using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public Rigidbody2D gameobject;
    public int playerspeed = 10;
    private bool facingright = true;
    public int playerJumpPower = 1250;
    private float moveX;

    public LayerMask ground;

    public Transform feet;
    public bool isGrounded = false;



    // Start is called before the first frame update
    void Start()
    {   
        isGrounded = false;
    }

    // Update is called once per frame
    void Update() 
    {
        PlayerMove();
    }
    
    void PlayerMove(){
        //Controls
        moveX = Input.GetAxisRaw("Horizontal"); 
        Debug.Log(isGrounded);
        if (Input.GetButtonDown("Jump") && isGrounded == true){
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

//     public bool isGrounded() {
//       Collider2D groundcheck = Physics2D.OverlapCircle(feet.position, 0.5f, ground);
//       Debug.Log(groundcheck.gameObject);
//       if (groundcheck.gameObject != null){
//           return true;
//       }

//       return false;
//   }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag ("ground")) {
            isGrounded = true;
        }
    }
 
    void OnCollisionExit2D(Collision2D hit)
    {
        isGrounded = false;
    }

};
