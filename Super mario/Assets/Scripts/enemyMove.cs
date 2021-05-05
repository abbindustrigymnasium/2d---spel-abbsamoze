using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{

    public int enemySpeed;
    public int XMoveDirection;
    public AudioSource DieMobSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (XMoveDirection, 0) * enemySpeed;
        if (hit.distance < 0.4f) {
            flip(); 
            if (hit.collider.tag == "Player") {
                //Destroy (hit.collider.gameObject);
                DieMobSound.Play();                
                Destroy(hit.collider.gameObject.GetComponent<BoxCollider2D>());
            
            }
        }
    }


    void flip () {
        if (XMoveDirection > 0) {
            XMoveDirection = -1;
        } else {
            XMoveDirection = 1;
        }
}
}
