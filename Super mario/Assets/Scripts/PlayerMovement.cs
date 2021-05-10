using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public Rigidbody2D gameobject;
    public int playerspeed = 10;
    public bool facingright = true;
    public int playerJumpPower = 1250;
    private float moveX;

    public LayerMask ground;

    public Transform feet;

    public AudioSource jumpSound;



    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update() 
    {
        PlayerMove();
        PlayerRaycast();
    }
    
    void PlayerMove(){
        //Controls
        moveX = Input.GetAxisRaw("Horizontal"); 
        if (Input.GetButtonDown("Jump") && IsGrounded()){
            Jump();
        }
        //Animations 

        if (moveX != 0) {
            GetComponent<Animator>().SetBool ("IsRunning", true);
        } else {
            GetComponent<Animator>().SetBool ("IsRunning", false);
        }

        //Player direction
        if (moveX > 0.0f && facingright == false) {
            FlipPlayer();
        } else if (moveX < 0.0f && facingright == true) {
            FlipPlayer();
        };
        //Physics
       gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerspeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);   

    }

    void Jump(){
        //Jump code
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
        jumpSound.Play();

    }

    void FlipPlayer(){
        facingright = !facingright;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, ground);

 

        if (groundCheck != null)
        {
            return true;
        }
        return false;
    }
 
    

    void PlayerRaycast () {
        RaycastHit2D rayup = Physics2D.Raycast (transform.position, Vector2.up);
        if (rayup.collider != null && rayup.distance < 0.9f && rayup.collider.tag == "PowerUp") {
            Destroy(rayup.collider.gameObject);
        }
    

        RaycastHit2D raydown = Physics2D.Raycast (transform.position, Vector2.down);
        if (raydown.collider != null && raydown.distance < 0.9f && raydown.collider.tag == "Enemy") {
            GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 100);
            raydown.collider.gameObject.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;
            raydown.collider.gameObject.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 2;
            raydown.collider.gameObject.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
            raydown.collider.gameObject.gameObject.GetComponent<enemyMove> ().enabled = false;
        }
    }


}
